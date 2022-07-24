using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Interfaces;

namespace Products_CRUD_Microservice.Repository.Products.Interfaces
{
    public interface IProductRepository: IGetRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>
    {
        
    }
}
