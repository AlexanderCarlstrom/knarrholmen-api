using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using api.Entities;

namespace api.Contracts.Requests
{
    public class BookingRequest
    {
        [Required] public DateTime Start { get; set; }
        [Required] public DateTime End { get; set; }
        [Required] public string ActivityId { get; set; }
        public ClaimsPrincipal UserPrincipal { get; set; }
    }
}