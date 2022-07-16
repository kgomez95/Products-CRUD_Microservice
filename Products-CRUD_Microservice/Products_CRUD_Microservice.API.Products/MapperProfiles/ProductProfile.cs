using AutoMapper;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Models.Products.DTO;

namespace Products_CRUD_Microservice.API.Products.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            base.CreateMap<Product, ProductDTO>();
            base.CreateMap<ProductDTO, Product>();
        }
    }
}
