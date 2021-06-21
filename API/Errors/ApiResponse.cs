using System;

namespace API
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFromStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side...",
                _ => null
            };
        }
    }
}