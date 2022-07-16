using Microsoft.AspNetCore.Mvc;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Services.Products.Interfaces;

namespace Products_CRUD_Microservice.API.Products.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    [Route(ProductsValues.Controller.ROUTE)]
    public class Products10Controller : ControllerBase
    {
        protected readonly IProductService _productService;

        public Products10Controller(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_BY_ID)]
        [MapToApiVersion("1.0")]
        public IActionResult GetById(int id)
        {
            ProductDTO? productDTO = this._productService.GetById(id);

            if (productDTO != null)
            {
                return base.Ok(productDTO);
            }

            return base.NotFound(string.Format("El producto con ID '{0}' no existe en nuestros sistemas.", id));
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_BY_NAME)]
        [MapToApiVersion("1.0")]
        public IActionResult GetByName(string name)
        {
            try
            {
                // Comprobamos que la petición sea correcta. Si no lo es, devolvemos un error 400.
                if (string.IsNullOrEmpty(name))
                {
                    return base.BadRequest("Es necesario especificar un nombre para filtrar por nombre de producto.");
                }

                // Llamamos al servicio para realizar la búsqueda del producto filtrando por nombre.
                ProductDTO? productDTO = this._productService.GetByName(name);

                // Si no hay producto devolvemos un error 404.
                if (productDTO == null)
                {
                    return base.NotFound(string.Format("El producto con nombre '{0}' no existe en nuestros sistemas.", name));
                }

                // Devolvemos el producto con un estado 200.
                return base.Ok(productDTO);
            }
            catch (Exception ex)
            {
                // NOTE: Aquí pintaríamos la excepción en un fichero ".log".
                return base.StatusCode(500, "Se ha producido un error general en el servicio. Por favor, contacte con un administrador.");
            }
        }

        [HttpGet(ProductsValues.Controller.Actions.CREATE)]
        [MapToApiVersion("1.0")]
        public IActionResult Create()
        {
            return Ok("¡Producto creado!");
        }

        //[Route("/error-development")]
        //public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        //{
        //    if (!hostEnvironment.IsDevelopment())
        //    {
        //        return NotFound();
        //    }

        //    IExceptionHandlerFeature exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        //    return Problem(
        //        detail: exceptionHandlerFeature.Error.StackTrace,
        //        title: exceptionHandlerFeature.Error.Message);
        //}

        //[Route("/error")]
        //public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
        //{
        //    IExceptionHandlerFeature exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        //    // TODO: Mostrar error general y pintar logs.
        //    //exceptionHandlerFeature.Error

        //    throw new NotImplementedException();
        //}

        // TODO: Intentar buscar alguna forma para no estar poniendo siempre "try catch" en todas las funciones del controlador. Intentar buscar algún método que sea común para todas las funciones,
        //       de forma que se pinte un log con toda la información posible incluyendo la excepción.
        //       https://docs.microsoft.com/es-es/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0


        // TODO: Crear un middleware para controlar las excepciones:
        //       https://stackoverflow.com/questions/43358224/how-can-i-throw-an-exception-in-an-asp-net-core-webapi-controller-that-returns-a
    }
}
