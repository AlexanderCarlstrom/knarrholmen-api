using System.Collections.Generic;
using api.Entities;

namespace api.DTOs
{
    public class ActivityDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }
    }
}