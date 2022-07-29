using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Interfaces;

namespace Products_CRUD_Microservice.Repository.Products.Interfaces
{
    public interface IProductRepository: IGetRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>, IDeleteRepository<Product>
    {
        /// <summary>
        /// Obtiene uno o varios productos filtrando por cualquiera de sus valores.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar.</param>
        /// <param name="description">Descripción del producto a buscar.</param>
        /// <param name="price">Precio del producto a buscar.</param>
        /// <param name="createdAt">Fecha de creación del producto a buscar.</param>
        /// <param name="updatedAt">Fecha de actualización del producto a buscar.</param>
        /// <param name="enabled">Producto activado o desactivado.</param>
        /// <returns>Retorna un listado de productos.</returns>
        Product[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled);
    }
}
