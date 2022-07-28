using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Interfaces;

namespace Products_CRUD_Microservice.Repository.Products.Interfaces
{
    public interface IProductRepository: IGetRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>, IDeleteRepository<Product>
    {
        Product[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled);
    }
}
