using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Contexts;
using api.Contracts;
using api.Contracts.Requests;
using api.Contracts.Responses;
using api.DTOs;
using api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace api.Services
{
    public interface IBookingService
    {
        /// <summary>
        /// Create a new booking
        /// </summary>
        Task<ApiResponse> Create(BookingRequest model);

        /// <summary>
        /// Get all bookings in given week
        /// </summary>
        Task<BookingResponse> GetBookingsWeek(BookingsWeekRequest model);

        /// <summary>
        /// Get all bookings in given day
        /// </summary>
        Task<BookingResponse> GetBookingsDay(BookingsDayRequest model);

        /// <summary>
        /// Get all future bookings for current user
        /// </summary>
        Task<BookingResponse> GetFutureBookings(ClaimsPrincipal userPrincipal);

        /// <summary>
        /// Get all past bookings for current user
        /// </summary>
        Task<BookingResponse> GetPastBookings(ClaimsPrincipal userPrincipal);

        /// <summary>
        /// Delete booking
        /// </summary>
        Task<ApiResponse> DeleteBooking(string id, ClaimsPrincipal userPrincipal);
    }

    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public BookingService(BookingDbContext context, UserManager<User> userManager, IMapper mapper)
        {
            _bookingDbContext = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Create(BookingRequest model)
        {
            // Check if activity exist
            var activity = await _bookingDbContext.Activities.FindAsync(model.ActivityId);
            if (activity == null) return new ApiResponse(400, "Activity does not exist");

            // Check if booking is within open hours
            if (model.Start.Hour < activity.Open || model.Start.Hour >= activity.Close)
                return new ApiResponse(400, "Booking cannot be made outside of open hours");

            // Get current user
            var user = await _userManager.GetUserAsync(model.UserPrincipal);

            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains(UserRoles.Admin))
            {
                // Check if bookings is to long
                var diff = model.End - model.Start;
                if (diff.TotalMinutes > 60) return new ApiResponse(400, "Booking time is to long");
                // Check if user already have a booking that day
                var from = new DateTime(model.Start.Year, model.Start.Month, model.Start.Day);
                var to = GetNextDay(from);
                var result = await _bookingDbContext.Bookings.AnyAsync(b =>
                    b.ActivityId == model.ActivityId && b.UserId == user.Id && b.Start >= from && b.Start < to);
                if (result) return new ApiResponse(400, "Cannot make more than one booking per day and activity");
            }

            // Check if there is already a booking at that time
            var exist = await _bookingDbContext.Bookings.AnyAsync(b =>
                b.ActivityId == model.ActivityId && b.Start < model.End && model.Start < b.End);
            if (exist) return new ApiResponse(400, "A booking already exist in time period");

            var booking = new Booking
                {Start = model.Start, End = model.End, ActivityId = model.ActivityId, UserId = user.Id};
            await _bookingDbContext.Bookings.AddAsync(booking);
            await _bookingDbContext.SaveChangesAsync();

            return new ApiResponse(true, 201);
        }

        public async Task<BookingResponse> GetBookingsWeek(BookingsWeekRequest model)
        {
            // Get activity and check if it exists
            var activity = await _bookingDbContext.Activities.Include(a => a.Bookings)
                .Where(a => a.Id == model.ActivityId).FirstAsync();
            if (activity == null) return new BookingResponse(400, "Activity does not exist");

            var date = DateTime.Now;
            // Check if year is in the before or more than 1 year after current year
            if (model.Year < date.Year || model.Year > date.Year + 1)
                return new BookingResponse(400, "Year must be current or next year");

            // Check if week is before current week
            if (model.Year == date.Year && model.Week < ISOWeek.GetWeekOfYear(date))
                return new BookingResponse(400, "Week must be in the future");

            // Check if week is less than 1
            if (model.Week < 1) return new BookingResponse(400, "Week must be at least 1");
            var numberOfWeeks = ISOWeek.GetWeeksInYear(model.Year);

            // Check if week is more than number of weeks in given year
            if (model.Week > numberOfWeeks)
                return new BookingResponse(400, "Week must be at most " + numberOfWeeks);

            // Calculate from and to dates for use in query
            var centralEuropean = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, centralEuropean);
            var startOfWeek = ISOWeek.ToDateTime(model.Year, model.Week, DayOfWeek.Monday);
            var from = now > startOfWeek ? now : startOfWeek;
            var nextWeek = model.Week == numberOfWeeks ? 1 : model.Week + 1;
            var newYear = model.Week == numberOfWeeks ? model.Year + 1 : model.Year;
            var to = ISOWeek.ToDateTime(newYear, nextWeek, DayOfWeek.Monday);

            // Get bookings in given week from now
            var bookings = activity.Bookings.Where(b => b.Start >= from && b.Start < to);

            var openHours = activity.Close - activity.Open;
            var times = new int[7][];
            // Generate array with all bookings in a week
            for (var i = 0; i < 7; i++)
            {
                times[i] = new int[openHours];
                for (var j = 0; j < openHours; j++)
                {
                    var dateTime = startOfWeek.AddDays(i).AddHours(activity.Open + j);
                    if (now > dateTime)
                    {
                        times[i][j] = 2;
                    }
                }
            }

            // Go through bookings and set times as booked
            foreach (var booking in bookings)
            {
                var current = booking.Start;
                while (current < booking.End)
                {
                    var day = GetDayOfWeek(current.DayOfWeek);
                    var hour = current.Hour - activity.Open;
                    if (times[day][hour] != 2)
                    {
                        times[day][hour] = 1;
                    }

                    current = current.AddHours(1);
                }
            }


            return new BookingResponse(times);
        }

        public async Task<BookingResponse> GetBookingsDay(BookingsDayRequest model)
        {
            // Get activity and check if it exists
            var activity = await _bookingDbContext.Activities.Include(a => a.Bookings)
                .Where(a => a.Id == model.ActivityId).FirstAsync();
            if (activity == null) return new BookingResponse(400, "Activity does not exist");

            var today = DateTime.Today;
            // Check if date is in the past
            if (model.Date < today) return new BookingResponse(400, "Date must be in the future");

            var year = model.Date.Year;
            var month = model.Date.Month;
            var day = model.Date.Day;

            var date = new DateTime(year, month, day);
            var centralEuropean = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, centralEuropean);
            var from = now > date ? now : date;

            var to = GetNextDay(from);

            // Get bookings in given day
            var bookings = activity.Bookings.Where(booking => booking.Start >= from && booking.Start < to);

            var times = new List<int>();
            now = DateRoundUp(now);
            for (var i = activity.Open; i < activity.Close; i++)
            {
                if (now <= date.AddHours(i))
                {
                    times.Add(i);
                }
            }

            var openHours = activity.Close - activity.Open;
            // Go through bookings and set times as booked
            foreach (var booking in bookings)
            {
                var current = booking.Start;
                while (current < booking.End)
                {
                    Console.WriteLine(current);
                    times.Remove(current.Hour);
                    current = current.AddHours(1);
                }
            }

            return new BookingResponse(times);
        }

        public async Task<BookingResponse> GetFutureBookings(ClaimsPrincipal userPrincipal)
        {
            // Get current user
            var user = await _userManager.GetUserAsync(userPrincipal);
            var now = DateTime.Now;

            // Get future bookings
            var bookings = await _bookingDbContext.Bookings
                .Where(booking => booking.UserId == user.Id && booking.Start >= now).OrderBy(booking => booking.Start)
                .Include(booking => booking.Activity)
                .Select(booking => _mapper.Map<PrivateBookingsDto>(booking)).ToListAsync();

            foreach (var booking in bookings)
            {
                booking.Activity = _mapper.Map<ActivityDto>(booking.Activity);
            }

            return new BookingResponse(bookings);
        }

        public async Task<BookingResponse> GetPastBookings(ClaimsPrincipal userPrincipal)
        {
            // Get current user
            var user = await _userManager.GetUserAsync(userPrincipal);
            var now = DateTime.Now;

            // Get past bookings
            var bookings = await _bookingDbContext.Bookings
                .Where(booking => booking.UserId == user.Id && booking.Start < now).OrderBy(booking => booking.Start)
                .Include(booking => booking.Activity)
                .Select(booking => _mapper.Map<PrivateBookingsDto>(booking)).ToListAsync();
            
            foreach (var booking in bookings)
            {
                booking.Activity = _mapper.Map<ActivityDto>(booking.Activity);
            }

            return new BookingResponse(bookings);
        }

        public async Task<ApiResponse> DeleteBooking(string id, ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null) return new ApiResponse(400, "Could not find user");

            var booking = await _bookingDbContext.Bookings.FindAsync(id);
            if (booking == null) return new ApiResponse(400, "Could not find booking");

            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains(UserRoles.Admin))
            {
                if (booking.UserId == user.Id) return new ApiResponse(400, "User does not own booking");
            }

            _bookingDbContext.Bookings.Remove(booking);
            await _bookingDbContext.SaveChangesAsync();
            return new ApiResponse(true, 200, "Removed booking");
        }

        /// <summary>
        /// Calculates next day from given datetime
        /// </summary>
        private static DateTime GetNextDay(DateTime today)
        {
            var year = today.Year;
            var month = today.Month;
            var day = today.Day;

            if (month == 12)
            {
                year++;
                month = 1;
                day = 1;
            }
            else if (day == DateTime.DaysInMonth(year, month))
            {
                month++;
                day = 1;
            }
            else day++;

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Gets the correct day of week
        /// </summary>
        private int GetDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return 0;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 3;
                case DayOfWeek.Friday:
                    return 4;
                case DayOfWeek.Saturday:
                    return 5;
                case DayOfWeek.Sunday:
                    return 6;
                default:
                    throw new ArgumentOutOfRangeException(nameof(day), day, null);
            }
        }

        private DateTime DateRoundUp(DateTime date)
        {
            var thisHour = (new DateTime(date.Year, date.Month, date.Day)).AddHours(date.Hour);
            return thisHour < date ? thisHour.AddHours(1) : thisHour;
        }
    }
}