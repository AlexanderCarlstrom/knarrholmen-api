using System;
using System.Globalization;
using System.Threading.Tasks;
using api.Contracts;
using api.Contracts.Requests;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("bookings")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BookingRequest model)
        {
            if (model.End <= model.Start) return BadRequest("End time must be after start time");
            model.UserPrincipal = this.User;

            var response = await _bookingService.Create(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("week")]
        public async Task<IActionResult> GetBookingsWeek([FromQuery] BookingsWeekRequest model)
        {
            var response = await _bookingService.GetBookingsWeek(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsDay([FromQuery] BookingsDayRequest model)
        {
            var response = await _bookingService.GetBookingsDay(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Authorize]
        [Route("future")]
        public async Task<IActionResult> GetFutureBookings()
        {
            var userPrincipal = this.User;
            var response = await _bookingService.GetFutureBookings(userPrincipal);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpGet]
        [Authorize]
        [Route("past")]
        public async Task<IActionResult> GetPastBookings()
        {
            var userPrincipal = this.User;
            var response = await _bookingService.GetPastBookings(userPrincipal);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            var response = await _bookingService.DeleteBooking(id, this.User);
            return StatusCode(response.StatusCode, response);
        }
    }
}