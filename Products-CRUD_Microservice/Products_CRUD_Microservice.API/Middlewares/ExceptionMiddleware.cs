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
                    await context.Response.WriteAsync(new ApiResponse<string>(ex.StatusCode, ex.Message, null).ToJSON());
                }
            }
            catch (Exception ex)
            {
                // NOTE: Aquí pintaríamos la excepción en un fichero log.

                // TODO: Hacer que el "application/json" esté almacenado en una constante.
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(new ApiResponse<string>(context.Response.StatusCode, "Se ha producido un error general. Por favor, contacte con un administrador.", null).ToJSON());
            }
        }
    }
}
