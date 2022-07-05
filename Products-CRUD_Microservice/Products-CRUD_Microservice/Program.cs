using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_CRUD_Microservice.DbContexts;

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
builder.Services.AddSwaggerGen();

// Añadimos el ProductContext y le especificamos la cadena de conexión del AppSettings.
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
