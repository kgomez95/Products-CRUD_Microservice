using Products_CRUD_Microservice.API.Models;
using System.Net;

namespace Products_CRUD_Microservice.Exceptions.StatusExceptions
{
    public class NotFoundException : StatusException
    {
        public NotFoundException()
            : this("")
        { }

        public NotFoundException(string? message)
            : base(HttpStatusCode.NotFound, message)
        { }

        public NotFoundException(ApiError[] errors)
            : base(HttpStatusCode.NotFound, errors)
        { }
    }
}
