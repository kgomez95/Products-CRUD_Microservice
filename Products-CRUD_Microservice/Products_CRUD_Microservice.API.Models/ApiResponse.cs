
namespace Products_CRUD_Microservice.API.Models
{
    public class ApiResponse<T>
    {
        #region Protected variables.
        protected virtual int _statusCode { get; set; }
        protected virtual T? _data { get; set; }
        protected virtual ApiError[]? _errors { get; set; }
        #endregion

        #region Public variables.
        public virtual int StatusCode { get => this._statusCode; }
        public virtual T? Data { get => this._data; }
        public virtual ApiError[]? Errors { get => this._errors; }
        #endregion

        public ApiResponse(int statusCode)
        {
            this._statusCode = statusCode;
        }

        public ApiResponse(int statusCode, T? data)
            : this(statusCode)
        {
            this._data = data;
        }

        public ApiResponse(int statusCode, string? errorMessage)
            : this(statusCode, errorMessage, null)
        { }

        public ApiResponse(int statusCode, string? errorMessage, string? errorDetails)
            : this(statusCode)
        {
            this._errors = new ApiError[]
            {
                new ApiError(errorMessage, errorDetails)
            };
        }

        public ApiResponse(int statusCode, ApiError[] errors)
            : this(statusCode)
        {
            this._errors = errors;
        }
    }
}
