using Microsoft.AspNetCore.Http;
using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Exceptions;
using Products_CRUD_Microservice.Utils.Extensions;
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
            catch (StatusException ex)
            {
                context.Response.ContentType = ex.ContentType;
                context.Response.StatusCode = ex.StatusCode;

                if (ex.Errors != null)
                {
                    await context.Response.WriteAsync(new ApiResponse<string>(ex.StatusCode, ex.Errors).ToJSON());
                }
                else
                {
                    await context.Response.WriteAsync(new ApiResponse<string>(ex.StatusCode, ex.Message).ToJSON());
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // TODO: Crear un objeto de respuesta con el error y retornarlo.
                await context.Response.WriteAsync("Se ha producido un error general. Por favor, contacte con un administrador.");
            }
        }
    }
}
