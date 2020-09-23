using System.Collections.Generic;

namespace TestApi.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public ErrorResponse(List<ErrorModel> errors)
        {
            Errors = errors;
        }

        public ErrorResponse()
        {
        }
    }
}
