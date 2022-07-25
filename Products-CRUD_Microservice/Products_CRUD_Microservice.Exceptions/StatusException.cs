using Products_CRUD_Microservice.API.Models;
using System.Net;

namespace Products_CRUD_Microservice.Exceptions
{
    public class StatusException : Exception
    {
        #region Protected variables.
        protected virtual int _statusCode { get; set; }
        protected virtual string _contentType { get; set; }
        protected virtual ApiError[]? _errors { get; set; }
        #endregion

        #region Public variables.
        public virtual int StatusCode { get => this._statusCode; }
        public virtual string ContentType { get => this._contentType; }
        public virtual ApiError[]? Errors { get => this._errors; }
        #endregion

        public StatusException(HttpStatusCode statusCode, string? message)
            : base(
                  (!string.IsNullOrEmpty(message)) ? message : "Se ha producido un error general. Por favor, contacte con un administrador."
                  )
        {
            this._statusCode = ((int)statusCode);
            this._contentType = "application/json";

            // TODO: Hacer que el "application/json" esté almacenado en una constante.
        }

        public StatusException(HttpStatusCode statusCode, ApiError[] errors)
            : this(statusCode, "")
        {
            this._errors = errors;
        }
    }
}
