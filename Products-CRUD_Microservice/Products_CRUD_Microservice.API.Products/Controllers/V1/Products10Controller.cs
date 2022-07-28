using Microsoft.AspNetCore.Mvc;
using Products_CRUD_Microservice.API.Attributes;
using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.Exceptions.StatusExceptions;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Services.Products.Interfaces;
using Products_CRUD_Microservice.Utils;
using System.Net;

namespace Products_CRUD_Microservice.API.Products.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    [Route(ProductsValues.Controller.ROUTE)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
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
            ApiResponse<ProductDTO>? response = null;

            // Llamamos al servicio para realizar la búsqueda del producto filtrando por id.
            ProductDTO? productDTO = this._productService.GetById(id);
            response = new ApiResponse<ProductDTO>((int)HttpStatusCode.OK, productDTO);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_BY_NAME)]
        [MapToApiVersion("1.0")]
        public IActionResult GetByName(string name)
        {
            ApiResponse<ProductDTO>? response = null;

            // Comprobamos que la petición sea correcta. Si no lo es, devolvemos un error 400.
            if (string.IsNullOrEmpty(name))
            {
                // NOTE: Esta condición no es necesaria en este caso, ya que estamos aplicando el atributo "ServiceFilter" a todas las funciones del controlador.
                throw new BadRequestException("Es necesario especificar un nombre para filtrar por nombre de producto.");
            }

            // Llamamos al servicio para realizar la búsqueda del producto filtrando por nombre.
            ProductDTO? productDTO = this._productService.GetByName(name);
            response = new ApiResponse<ProductDTO>((int)HttpStatusCode.OK, productDTO);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_ALL)]
        [MapToApiVersion("1.0")]
        public IActionResult GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled)
        {
            ApiResponse<ProductDTO[]>? response = null;

            // Llamamos al servicio para recuperar los productos.
            ProductDTO[] productsDTO = this._productService.GetAll(name, description, price, createdAt, updatedAt, enabled);
            response = new ApiResponse<ProductDTO[]>((int)HttpStatusCode.OK, productsDTO);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
        }

        [HttpPost(ProductsValues.Controller.Actions.CREATE)]
        [MapToApiVersion("1.0")]
        public IActionResult Create([FromBody] ProductDTO requestDTO)
        {
            ApiResponse<ProductDTO>? response = null;

            // Llamamos al servicio para crear el producto.
            ProductDTO? productDTO = this._productService.Create(requestDTO);
            response = new ApiResponse<ProductDTO>((int)HttpStatusCode.OK, productDTO);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
        }

        [HttpPut(ProductsValues.Controller.Actions.UPDATE)]
        [MapToApiVersion("1.0")]
        public IActionResult Update([FromBody] ProductDTO requestDTO)
        {
            ApiResponse<ProductDTO>? response = null;

            // Llamamos al servicio para crear el producto.
            ProductDTO? productDTO = this._productService.Update(requestDTO);
            response = new ApiResponse<ProductDTO>((int)HttpStatusCode.OK, productDTO);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
        }

        [HttpDelete(ProductsValues.Controller.Actions.DELETE)]
        [MapToApiVersion("1.0")]
        public IActionResult Delete(int id)
        {
            ApiResponse<string> response = new ApiResponse<string>((int)HttpStatusCode.OK, String.Format("El producto con ID '{0}' se ha borrado correctamente.", id));

            // Llamamos al servicio para borrar el producto.
            this._productService.Delete(id);

            // Devolvemos el producto con un estado 200.
            return base.StatusCode(response.StatusCode, response);
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
