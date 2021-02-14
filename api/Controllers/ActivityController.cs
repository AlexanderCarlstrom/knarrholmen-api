using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Contexts;
using api.Contracts;
using api.Contracts.Requests;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("activities")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly BookingDbContext _bookingDbContext;

        public ActivityController(IActivityService activityService, BookingDbContext bookingDbContext)
        {
            _activityService = activityService;
            _bookingDbContext = bookingDbContext;
        }
        
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create([FromBody] ActivityRequest model)
        {
            var response = await _activityService.Create(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Please provide a valid activity id");
            var response = await _activityService.GetOne(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] ActivitySearchRequest model)
        {
            var response = _activityService.Search(model);
            return StatusCode(response.StatusCode, response);
        }
    }
}