using System;
using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Booking
    {
        [Key] public string Id { get; set; }
        [Required] public DateTime Start { get; set; }
        [Required] public DateTime End { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string ActivityId { get; set; }
        public Activity Activity { get; set; }

        public Booking()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}