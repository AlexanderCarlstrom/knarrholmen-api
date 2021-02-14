

namespace api.Contracts.Requests
{
    public class LogoutRequest
    {
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}