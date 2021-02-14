using System.ComponentModel.DataAnnotations;

namespace api.Contracts.Requests
{
    public class ConfirmEmailRequest
    {
        [Required(ErrorMessage = "User id is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }
    }
}