using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}