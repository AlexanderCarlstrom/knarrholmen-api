using System;

namespace api.Contracts.Requests
{
    public class BookingsDayRequest
    {
        public DateTime Date { get; set; }
        public string ActivityId { get; set; }
    }
}