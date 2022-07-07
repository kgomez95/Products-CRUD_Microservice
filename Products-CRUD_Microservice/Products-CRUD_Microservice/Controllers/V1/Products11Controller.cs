using Microsoft.AspNetCore.Mvc;
using Products_CRUD_Microservice.Constants.Products;

namespace Products_CRUD_Microservice.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.1")]
    [ApiExplorerSettings(GroupName = "v1.1")]
    [Route(ProductsValues.Controller.ROUTE)]
    public class Products11Controller : ControllerBase
    {
        [HttpGet(ProductsValues.Controller.Actions.GET_BY_ID)]
        [MapToApiVersion("1.1")]
        public IActionResult GetById(int id)
        {
            return Ok(string.Format("V1.1: ¡Producto con ID '{0}' obtenido!", id));
        }
    }
}
