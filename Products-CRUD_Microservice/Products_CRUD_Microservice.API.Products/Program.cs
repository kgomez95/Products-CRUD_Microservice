using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.API.Products.MapperProfiles;
using Products_CRUD_Microservice.Repository.Products.Definitions;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Services.Products.Definitions;
using Products_CRUD_Microservice.Services.Products.Interfaces;
using Products_CRUD_Microservice.SwaggerVersion;
using Products_CRUD_Microservice.SwaggerVersion.Models;
using static System.Net.Mime.MediaTypeNames;

// TODO: Crear un proyecto genérico, el cual pueda ser utilizado por todos los microservicios, y que se encargue de inicializar el Program (o Startup) del microservicio en cuestión.

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddControllers()
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

// ApiVersioning.
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.ReportApiVersions = true;
    config.AssumeDefaultVersionWhenUnspecified = true;
});


// TODO: Intentar hacer que Swagger muestre la estructura de las peticiones y de las respuestas de cada endpoint.
//       Buscar en Google: "asp.net core 6 swagger request schema example"
//       https://code-maze.com/swagger-ui-asp-net-core-web-api/

// Se recogen los documentos Swagger de productos.
SwaggerDoc[] swaggerDocs = Documentation.GetDocumentations(Path.Combine(builder.Environment.ContentRootPath, ProductsValues.Api.DOCUMENTATION_FILE));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    foreach (SwaggerDoc swaggerDoc in swaggerDocs)
    {
        x.SwaggerDoc(swaggerDoc.GroupName, new OpenApiInfo()
        {
            Version = swaggerDoc.Version,
            Title = swaggerDoc.Title,
            Description = swaggerDoc.Description
        });
    }

    x.ResolveConflictingActions(a => a.First());
    x.OperationFilter<RemoveVersionFromParameter>();
    x.DocumentFilter<ReplaceVersionWithExactValueInPath>();
});

// Añadimos el ProductContext y le especificamos la cadena de conexión del AppSettings.
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", x => x.MigrationsAssembly(ProductsValues.DbContext.MIGRATIONS_ASSEMBLY)));

// Añadimos el perfil del automapper de productos y la injección de su servicio.
MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Injección de repositorios.
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Injección de servicios.
builder.Services.AddScoped<IProductService, ProductService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        foreach (SwaggerDoc swaggerDoc in swaggerDocs)
        {
            x.SwaggerEndpoint(String.Format("/swagger/{0}/swagger.json", swaggerDoc.Version), swaggerDoc.EndpointName);
        }
    });

    //app.UseExceptionHandler("/error-development");
}
else
{
    //app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
