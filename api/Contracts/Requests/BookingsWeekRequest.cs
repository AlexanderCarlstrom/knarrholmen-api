using System;
using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class BookingsWeekRequest
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public string ActivityId { get; set; }
    }
}