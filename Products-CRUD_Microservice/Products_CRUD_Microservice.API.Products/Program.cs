using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.API.Products.Initializers;

// Inicializamos los servicios.
ProductStartupService productStartupService = new ProductStartupService(args, ProductsValues.Api.DOCUMENTATION_FILE);
productStartupService.Init();

// Inicializamos la aplicación.
ProductStartupApplication productStartupApplication = new ProductStartupApplication(productStartupService.Builder, productStartupService.SwaggerDocs);
productStartupApplication.Init();
productStartupApplication.Run();
