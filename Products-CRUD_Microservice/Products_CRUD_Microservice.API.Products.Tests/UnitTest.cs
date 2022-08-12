using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Utils;

namespace Products_CRUD_Microservice.API.Products.Tests
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
            // NOTE: Esta función siempre se ejecuta antes de ejecutar un Test.
        }

        protected virtual ApiResponse<ProductDTO> GetProductById(int id)
        {
            return new RestClient<ApiResponse<ProductDTO>>(String.Format("https://localhost:7046/api/v1.0/products/getById?id={0}", id))
                .AddHeader("Accept", "application/json")
                .Execute();
        }

        protected virtual ApiResponse<ProductDTO> GetProductByName(string name)
        {
            return new RestClient<ApiResponse<ProductDTO>>(String.Format("https://localhost:7046/api/v1.0/products/getByName?name={0}", name))
                .AddHeader("Accept", "application/json")
                .Execute();
        }

        protected virtual ApiResponse<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            return new RestClient<ApiResponse<ProductDTO>>("https://localhost:7046/api/v1.0/products/create", HttpMethod.Post)
                .AddHeader("Accept", "application/json")
                .Execute(productDTO);
        }

        protected virtual ApiResponse<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            return new RestClient<ApiResponse<ProductDTO>>("https://localhost:7046/api/v1.0/products/update", HttpMethod.Put)
                .AddHeader("Accept", "application/json")
                .Execute(productDTO);
        }

        protected virtual ApiResponse<string> DeleteProduct(int id)
        {
            return new RestClient<ApiResponse<string>>(String.Format("https://localhost:7046/api/v1.0/products/delete?id={0}", id), HttpMethod.Delete)
                .AddHeader("Accept", "application/json")
                .Execute();
        }
    }
}
