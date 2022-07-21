using System.Net;

namespace Products_CRUD_Microservice.Exceptions.StatusExceptions
{
    public class NotFoundException : StatusException
    {
        public NotFoundException()
            : this(null)
        { }

        public NotFoundException(string? message)
            :base(HttpStatusCode.NotFound, message)
        { }
    }
}
