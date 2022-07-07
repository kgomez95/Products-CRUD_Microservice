using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.SwaggerVersion;
using Products_CRUD_Microservice.SwaggerVersion.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ApiVersioning.
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.ReportApiVersions = true;
    config.AssumeDefaultVersionWhenUnspecified = true;
});

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

// A�adimos el ProductContext y le especificamos la cadena de conexi�n del AppSettings.
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", x => x.MigrationsAssembly(ProductsValues.DbContext.MIGRATIONS_ASSEMBLY)));

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
