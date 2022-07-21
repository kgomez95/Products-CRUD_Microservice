namespace Products_CRUD_Microservice.API.Models
{
    public class ApiError
    {
        #region Protected variables.
        protected virtual string? _message { get; set; }
        protected virtual string? _details { get; set; }
        #endregion

        #region Public variables.
        public virtual string Message { get => this._message ?? ""; }
        public virtual string Details { get => this._details ?? ""; }
        #endregion

        public ApiError()
        { }

        public ApiError(string? message)
        {
            this._message = message;
        }

        public ApiError(string? message, string? details)
        {
            this._message = message;
            this._details = details;
        }
    }
}
