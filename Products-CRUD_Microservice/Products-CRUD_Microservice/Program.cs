using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.SwaggerVersion;

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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    // TODO: Trasladar la siguiente información a un documento json (por ejemplo) para leerlo y asignar los grupos de SwaggerDoc de forma dinámica (incluir también los SwaggerEndpoints).

    x.SwaggerDoc("v1.0", new OpenApiInfo()
    {
        Version = "v1.0",
        Title = "API V1.0 Title",
        Description = "API V1.0 Description"
    });

    x.SwaggerDoc("v1.1", new OpenApiInfo()
    {
        Version = "v1.1",
        Title = "API V1.1 Title",
        Description = "API V1.1 Description"
    });

    x.SwaggerDoc("v2.0", new OpenApiInfo()
    {
        Version = "v2.0",
        Title = "API V2.0 Title",
        Description = "API V2.0 Description"
    });

    x.ResolveConflictingActions(a => a.First());
    x.OperationFilter<RemoveVersionFromParameter>();
    x.DocumentFilter<ReplaceVersionWithExactValueInPath>();
});

// Añadimos el ProductContext y le especificamos la cadena de conexión del AppSettings.
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", x => x.MigrationsAssembly(ProductsValues.DbContext.MIGRATIONS_ASSEMBLY)));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        // TODO: Hacer uso del documento json que se debe crear para añadir los grupos de SwaggerDoc, para aprovechar el mismo fichero.

        x.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "API V1.0");
        x.SwaggerEndpoint($"/swagger/v1.1/swagger.json", "API V1.1");
        x.SwaggerEndpoint($"/swagger/v2.0/swagger.json", "API V2.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
