using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace api.Entities
{
    public class User : IdentityUser
    {
        [PersonalData] public string FirstName { get; set; }
        [PersonalData] public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<Booking> Bookings { get; set; }
        [NotMapped] public IEnumerable<string> Roles { get; set; }

        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            Bookings = new List<Booking>();
        }
    }
}