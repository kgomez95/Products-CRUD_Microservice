using Microsoft.AspNetCore.Http;
using System.Net;

namespace Products_CRUD_Microservice.API.Middlewares
{
    public class ExceptionMiddleware
    {
        protected readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            // TODO: Crear excepciones personalizadas con diferentes códigos de estado (por ejemplo, una excepción para mostrar códigos 404 cuando no se encuentre el recurso en base de datos.)

            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync("Se ha producido un error general. Por favor, contacte con un administrador.");

                // TODO: Crear un objeto de respuesta con el error y retornarlo.
            }
        }
    }
}
