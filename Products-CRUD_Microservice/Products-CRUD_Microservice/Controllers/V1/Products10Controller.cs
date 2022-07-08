using Microsoft.AspNetCore.Mvc;
using Products_CRUD_Microservice.Constants.Products;

namespace Products_CRUD_Microservice.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    [Route(ProductsValues.Controller.ROUTE)]
    public class Products10Controller : ControllerBase
    {
        public Products10Controller()
        {
            
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_BY_ID)]
        [MapToApiVersion("1.0")]
        public IActionResult GetById(int id)
        {
            return Ok(string.Format("¡Producto con ID '{0}' obtenido!", id));
        }

        [HttpGet(ProductsValues.Controller.Actions.GET_BY_NAME)]
        [MapToApiVersion("1.0")]
        public IActionResult GetByName(string name)
        {
            return Ok(string.Format("¡Producto con nombre '{0}' obtenido!", name));
        }

        [HttpGet(ProductsValues.Controller.Actions.CREATE)]
        [MapToApiVersion("1.0")]
        public IActionResult Create()
        {
            return Ok("¡Producto creado!");
        }

        // TODO: Crear una interfaz común para todos los controladores en la que se definan las funciones básicas que van a implementar sí o sí todas las funciones (mirar si es posible utilizar esta
        //       interfaz también para los servicios).
        // TODO: Montar también un sistema de versiones para los servicios que se encarguen de realizar la lógica del programa, ya que no basta con hacer versioning solamente de los controladores.
    }
}
