using Products_CRUD_Microservice.Exceptions.StatusExceptions;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Services.Interfaces;

namespace Products_CRUD_Microservice.Services.Products.Interfaces
{
    public interface IProductService : IGetService<ProductDTO>, ICreateService<ProductDTO>, IUpdateService<ProductDTO>, IDeleteService<ProductDTO>
    {
        /// <summary>
        /// Llama al repositorio para recuperar un listado de productos, pudiendo filtrar también por cualquiera de sus campos.
        /// </summary>
        /// <param name="name">Nombre del producto.</param>
        /// <param name="description">Descripción del producto.</param>
        /// <param name="price">Precio del producto.</param>
        /// <param name="createdAt">Fecha de creación del producto.</param>
        /// <param name="updatedAt">Fecha de actualización del producto.</param>
        /// <param name="enabled">Producto activado o desactivado.</param>
        /// <returns>Retorna el listado de productos que se ha encontrado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún listado de productos.</exception>
        ProductDTO[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled);
    }
}
