using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class ActivityRequest
    {
        [Required] public string Name { get; set; }
        [Required] public string Location { get; set; }
        public string Description { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }
    }
}