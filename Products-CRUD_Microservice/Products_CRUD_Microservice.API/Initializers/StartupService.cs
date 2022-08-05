using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Products_CRUD_Microservice.API.Attributes;
using Products_CRUD_Microservice.SwaggerVersion;
using Products_CRUD_Microservice.SwaggerVersion.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Products_CRUD_Microservice.API.Initializers
{
    public abstract class StartupService
    {
        #region Protected variables.

        protected readonly WebApplicationBuilder _builder;
        protected string _swaggerDocFileName { get; set; }
        protected SwaggerDoc[] _swaggerDocs { get; set; }

        #endregion

        #region Public variables.

        public WebApplicationBuilder Builder { get => this._builder; }
        public SwaggerDoc[] SwaggerDocs { get => _swaggerDocs; }

        #endregion

        public StartupService(string[] args, string swaggerDocFileName)
        {
            this._builder = WebApplication.CreateBuilder(args);
            this._swaggerDocFileName = swaggerDocFileName;
            this._swaggerDocs = new SwaggerDoc[0];
        }

        /// <summary>
        /// Ejecuta todas las funciones necesarias para inicializar el microservicio.
        /// </summary>
        public virtual void Init()
        {
            this.LoadSwaggerDocs();

            this.AddController();
            this.AddApiVersioning();
            this.AddSwaggerGen();
            this.AddDbContext();
            this.AddAutoMapper();
            this.AddServiceInjections();

            this.DisableValidationModel();
        }

        #region Initializers.

        /// <summary>
        /// Establece la versión actual de la API al microservicio correspondiente.
        /// </summary>
        protected abstract void AddApiVersioning();

        /// <summary>
        /// Añade el servicio AutoMapper al microservicio correspondiente.
        /// </summary>
        protected abstract void AddAutoMapper();

        /// <summary>
        /// Añade los servicios y las configuraciones a los controladores.
        /// </summary>
        protected virtual void AddController()
        {
            this._builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                        new BadRequestObjectResult(context.ModelState)
                        {
                            ContentTypes =
                            {
                                // using static System.Net.Mime.MediaTypeNames;
                                Application.Json
                            }
                        };
                })
                .AddNewtonsoftJson(options =>
                {
                    // Loop Include Fixed
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                });
        }

        /// <summary>
        /// Añade los contextos al microservicio correspondiente.
        /// </summary>
        protected abstract void AddDbContext();

        /// <summary>
        /// Inyecta los servicios a utilizar en el microservicio correspondiente.
        /// </summary>
        protected virtual void AddServiceInjections()
        {
            // NOTE: Sobreescribir esta función llamando siempre a la "base".

            this._builder.Services.AddScoped<ValidationFilterAttribute>();
        }

        /// <summary>
        /// Añade la documentación de Swagger al microservicio correspondiente.
        /// </summary>
        protected abstract void AddSwaggerGen();

        /// <summary>
        /// Desactiva las validaciones del modelo al recibir una petición.
        /// </summary>
        protected virtual void DisableValidationModel()
        {
            this._builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        /// <summary>
        /// Carga la documentación de Swagger mediante el fichero proporcionado por parámetros.
        /// </summary>
        protected virtual void LoadSwaggerDocs()
        {
            this._swaggerDocs = Documentation.GetDocumentations(Path.Combine(this._builder.Environment.ContentRootPath, this._swaggerDocFileName));
        }

        #endregion
    }
}
