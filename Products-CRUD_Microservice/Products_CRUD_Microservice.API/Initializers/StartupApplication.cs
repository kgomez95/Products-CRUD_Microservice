using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Products_CRUD_Microservice.API.Middlewares;
using Products_CRUD_Microservice.SwaggerVersion.Models;

namespace Products_CRUD_Microservice.API.Initializers
{
    public abstract class StartupApplication
    {
        #region Protected variables.

        protected readonly WebApplication _app;
        protected bool _isDevelopment { get; set; }
        protected SwaggerDoc[] _swaggerDocs { get; set; }

        #endregion

        public StartupApplication(WebApplicationBuilder builder, SwaggerDoc[] swaggerDocs)
        {
            this._app = builder.Build();
            this._isDevelopment = this._app.Environment.IsDevelopment();
            this._swaggerDocs = swaggerDocs;
        }

        /// <summary>
        /// Ejecuta todas las funciones necesarias para añadir todas las funcionalidades que utilizará el microservicio.
        /// </summary>
        public virtual void Init()
        {
            this.UseSwagger();
            this.UseHttpsRedirection();
            this.UseAuthorization();
            this.UseMiddleware();
            this.MapControllers();
        }

        /// <summary>
        /// Pone en marcha la aplicación.
        /// </summary>
        /// <remarks>Esta función es la última que se debe ejecutar.</remarks>
        public virtual void Run()
        {
            this._app.Run();
        }

        #region Initializers

        /// <summary>
        /// Añade los endpoints de los controladores del microservicio.
        /// </summary>
        protected virtual void MapControllers()
        {
            this._app.MapControllers();
        }

        /// <summary>
        /// Añade el middleware de autorización para el microservicio.
        /// </summary>
        protected virtual void UseAuthorization()
        {
            this._app.UseAuthorization();
        }

        /// <summary>
        /// Añade el middleware para redirigir las peticiones HTTP a HTTPS.
        /// </summary>
        protected virtual void UseHttpsRedirection()
        {
            this._app.UseHttpsRedirection();
        }

        /// <summary>
        /// Añade middlewares customizados.
        /// </summary>
        protected virtual void UseMiddleware()
        {
            this._app.UseMiddleware<ExceptionMiddleware>();
        }

        /// <summary>
        /// Añade los endpoints de Swagger haciendo uso de la documentación de Swagger.
        /// </summary>
        protected virtual void UseSwagger()
        {
            if (this._isDevelopment)
            {
                this._app.UseSwagger();
                this._app.UseSwaggerUI(x =>
                {
                    foreach (SwaggerDoc swaggerDoc in this._swaggerDocs)
                    {
                        x.SwaggerEndpoint(String.Format("/swagger/{0}/swagger.json", swaggerDoc.Version), swaggerDoc.EndpointName);
                    }
                });
            }
        }

        #endregion
    }
}
