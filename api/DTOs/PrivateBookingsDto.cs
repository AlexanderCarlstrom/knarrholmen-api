using System;
using api.Entities;

namespace api.DTOs
{
    public class PrivateBookingsDto
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ActivityDto Activity { get; set; }
    }
}