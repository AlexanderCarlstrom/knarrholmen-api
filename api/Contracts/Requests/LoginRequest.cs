using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}