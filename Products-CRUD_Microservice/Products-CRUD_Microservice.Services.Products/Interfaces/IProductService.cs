using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Services.Interfaces;

namespace Products_CRUD_Microservice.Services.Products.Interfaces
{
    public interface IProductService : IGetService<ProductDTO>, ICreateService<ProductDTO>, IUpdateService<ProductDTO>, IDeleteService<ProductDTO>
    {

    }
}
