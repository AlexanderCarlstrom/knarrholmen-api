using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class ActivitySearchRequest
    {
        public string Search { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
    }
}