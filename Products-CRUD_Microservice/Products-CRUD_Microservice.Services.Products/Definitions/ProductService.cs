using AutoMapper;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Services.Products.Interfaces;

namespace Products_CRUD_Microservice.Services.Products.Definitions
{
    public class ProductService : IProductService
    {
        protected readonly IMapper _mapper;
        protected readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public virtual ProductDTO GetById(int id)
        {
            try
            {
                Product product = this._productRepository.GetById(id);

                if (product != null)
                {
                    return this._mapper.Map<ProductDTO>(product);
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }

        public virtual ProductDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual ProductDTO Create(ProductDTO recordDTO)
        {
            throw new NotImplementedException();
        }
    }
}
