using EduTest.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EduTest.Infrastructure.Filters
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().Equals(typeof(ApiException)))
            {
                var ex = (ApiException)context.Exception;
                var info = new
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Bad Request",
                    Details = ex.Message
                };
                var result = new
                {
                    Errors = new[] { info }
                };
                context.Result = new BadRequestObjectResult(result);
                context.HttpContext.Response.StatusCode = Convert.ToInt32(StatusCodes.Status400BadRequest);
                context.ExceptionHandled = true;
            }
        }
    }
}
