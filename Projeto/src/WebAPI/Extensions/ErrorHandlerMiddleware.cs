using Domain.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;
using System.Net;
using System.Text.Json;

namespace WebAPI.Extensions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            string title = string.Empty;
            string type = string.Empty;
            switch (ex)
            {
                case AppExceptionBadRequest:
                    response.StatusCode = ((AppExceptionBadRequest)ex).StatusCode;
                    title = ((AppExceptionBadRequest)ex).Title;
                    type = ((AppExceptionBadRequest)ex).Type;
                    break;
                case AppExceptionNotFound:
                    response.StatusCode = ((AppExceptionNotFound)ex).StatusCode;
                    title = ((AppExceptionNotFound)ex).Title;
                    type = ((AppExceptionNotFound)ex).Type;
                    break;
                case AppException:
                    response.StatusCode = ((AppException)ex).StatusCode;
                    title = ((AppException)ex).Title;
                    type = ((AppException)ex).Type;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    title = "Internal server error";
                    type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1";
                    break;
            }
            var problemDetails = new ProblemDetails
            {
                Type = type,
                Title = title,
                Status = response.StatusCode,
                Instance = context.Request.Path,
                Detail = ex.Message
            };
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
