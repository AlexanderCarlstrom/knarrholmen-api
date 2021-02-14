using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api.Entities
{
    public class RefreshToken
    {
        [Key]
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        [JsonIgnore] public string UserId { get; set; }

        public RefreshToken(DateTime expiresAt)
        {
            Token = Guid.NewGuid().ToString();
            ExpiresAt = expiresAt;
        }
    }
}