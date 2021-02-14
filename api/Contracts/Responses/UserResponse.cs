using System.Collections.Generic;
using System.Text.Json.Serialization;
using api.DTOs;
using api.Entities;

namespace api.Contracts.Responses
{
    public class UserResponse : ApiResponse
    {
        public UserDTO User { get; set; }
        [JsonIgnore] public RefreshToken RefreshToken { get; set; }

        public UserResponse(int statusCode, UserDTO user)
            : base(true, statusCode)
        {
            User = user;
        }
        public UserResponse(int statusCode, UserDTO user, RefreshToken refreshToken)
            : base(true, statusCode)
        {
            User = user;
            RefreshToken = refreshToken;
        }

        public UserResponse(int statusCode, string message)
            : base(statusCode, message)
        {
        }

        public UserResponse(int statusCode, string message, IEnumerable<string> errors)
            : base(statusCode, message, errors)
        {
        }
    }
}