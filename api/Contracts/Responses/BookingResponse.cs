using System.Collections.Generic;
using api.DTOs;

namespace api.Contracts.Responses
{
    public class BookingResponse : ApiResponse
    {
        public List<PrivateBookingsDto> UserBookings { get; set; }
        public int[][] Week { get; set; }
        public List<int> Day { get; set; }
        

        public BookingResponse(List<PrivateBookingsDto> bookings) : base(true, 200)
        {
            UserBookings = bookings;
        }
        public BookingResponse(int[][] week) : base(true, 200)
        {
            Week = week;
        }
        public BookingResponse(List<int> day) : base(true, 200)
        {
            Day = day;
        }
        public BookingResponse(int statusCode, string message) : base(false, statusCode, message)
        {
        }
    }
}