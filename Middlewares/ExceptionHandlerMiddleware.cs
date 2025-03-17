using Azure.Core;
using CTPortaria.Exceptions;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net;

namespace CTPortaria.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            var message = exception.Message;
            var errorType = "Erro Interno";

            switch (exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorType = "Recurso Não Encontrado";
                    message = exception.Message;
                    break;

                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorType = "Erro de Validação";
                    message = JsonConvert.SerializeObject(validationException.Errors);
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Ocorreu um erro inesperado. Tente novamente mais tarde.";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                error = errorType,
                message = message
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
