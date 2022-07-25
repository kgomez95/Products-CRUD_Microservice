using Products_CRUD_Microservice.API.Models;
using System.Net;

namespace Products_CRUD_Microservice.Exceptions.StatusExceptions
{
    public class BadRequestException : StatusException
    {
        public BadRequestException()
            : this("")
        { }

        public BadRequestException(string? message)
            : base(HttpStatusCode.BadRequest, message)
        { }

        public BadRequestException(ApiError[] errors)
            : base(HttpStatusCode.BadRequest, errors)
        { }
    }
}
