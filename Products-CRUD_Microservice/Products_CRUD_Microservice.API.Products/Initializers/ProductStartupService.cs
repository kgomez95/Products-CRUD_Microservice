using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products_CRUD_Microservice.API.Initializers;
using Products_CRUD_Microservice.API.Products.MapperProfiles;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.Repository.Products.Definitions;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Services.Products.Definitions;
using Products_CRUD_Microservice.Services.Products.Interfaces;
using Products_CRUD_Microservice.SwaggerVersion;
using Products_CRUD_Microservice.SwaggerVersion.Models;

namespace Products_CRUD_Microservice.API.Products.Initializers
{
    public class ProductStartupService : StartupService
    {
        public ProductStartupService(string[] args, string swaggerDocFileName)
            : base(args, swaggerDocFileName)
        { }

        #region Initializers.

        protected override void AddApiVersioning()
        {
            base._builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        protected override void AddAutoMapper()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            base._builder.Services.AddSingleton(mapper);
        }

        protected override void AddDbContext()
        {
            base._builder.Services.AddDbContext<ProductContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", x => x.MigrationsAssembly(ProductsValues.DbContext.MIGRATIONS_ASSEMBLY)));
        }

        protected override void AddServiceInjections()
        {
            base.AddServiceInjections();

            // Inyección de repositorios.
            base._builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Inyección de servicios.
            base._builder.Services.AddScoped<IProductService, ProductService>();
        }

        protected override void AddSwaggerGen()
        {
            base._builder.Services.AddEndpointsApiExplorer();
            base._builder.Services.AddSwaggerGen(x =>
            {
                foreach (SwaggerDoc swaggerDoc in base._swaggerDocs)
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
        }

        #endregion
    }
}
