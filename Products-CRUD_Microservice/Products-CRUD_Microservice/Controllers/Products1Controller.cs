using Microsoft.AspNetCore.Mvc;

namespace Products_CRUD_Microservice.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class Products1Controller : ControllerBase
    {
        [HttpGet("getById")]
        [MapToApiVersion("1.0")]
        public IActionResult GetById(int id)
        {
            return Ok(string.Format("¡Producto con ID '{0}' obtenido!", id));
        }

        [HttpGet("getByName")]
        [MapToApiVersion("1.0")]
        public IActionResult GetByName(string name)
        {
            return Ok(string.Format("¡Producto con nombre '{0}' obtenido!", name));
        }
    }
}
