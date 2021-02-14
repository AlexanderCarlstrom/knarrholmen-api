using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace api.Entities
{
    public class Activity
    {
        [Key] public string Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public string Location { get; set; }
        [Required] public int Open { get; set; } = 0;
        [Required] public int Close { get; set; }
        [JsonIgnore] public List<Booking> Bookings { get; set; }

        public Activity(string name, string description, string location, int open = 0, int close = 24)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Location = location;
            Open = open;
            Close = close;
        }
    }
}