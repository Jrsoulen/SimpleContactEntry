using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace SimpleContactEntry
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new ContentResult
            {
                Content = $"Error: {exception.Message}",
                ContentType = "text/plain",
                StatusCode = (int?)HttpStatusCode.InternalServerError
            };
        }
    }
}
