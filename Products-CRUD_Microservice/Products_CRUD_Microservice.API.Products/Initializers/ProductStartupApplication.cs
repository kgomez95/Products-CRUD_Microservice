using Products_CRUD_Microservice.API.Initializers;
using Products_CRUD_Microservice.SwaggerVersion.Models;

namespace Products_CRUD_Microservice.API.Products.Initializers
{
    public class ProductStartupApplication : StartupApplication
    {
        public ProductStartupApplication(WebApplicationBuilder builder, SwaggerDoc[] swaggerDocs)
            : base(builder, swaggerDocs)
        { }
    }
}
