using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Contracts.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        [JsonIgnore] public int StatusCode { get; set; }

        /// <summary>
        /// Basic response
        /// </summary>
        public ApiResponse(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Basic response with message
        /// </summary>
        public ApiResponse(bool success, int statusCode, string message)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// Basic error response
        /// </summary>
        public ApiResponse(int statusCode, string message)
            : this(true, statusCode, message)
        {
        }

        public ApiResponse(int statusCode, string message, IEnumerable<string> errors)
            : this(false, statusCode, message)
        {
            Errors = errors;
        }
    }
}