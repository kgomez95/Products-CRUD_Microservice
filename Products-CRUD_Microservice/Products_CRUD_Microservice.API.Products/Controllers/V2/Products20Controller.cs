using Microsoft.AspNetCore.Mvc;
using Products_CRUD_Microservice.Constants.Products;

namespace Products_CRUD_Microservice.API.Products.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2.0")]
    [Route(ProductsValues.Controller.ROUTE)]
    public class Products20Controller : ControllerBase
    {
        [HttpGet(ProductsValues.Controller.Actions.GET_BY_ENABLED)]
        [MapToApiVersion("2.0")]
        public IActionResult GetByEnabled()
        {
            return Ok("¡Productos habilitados!");
        }
    }
}
