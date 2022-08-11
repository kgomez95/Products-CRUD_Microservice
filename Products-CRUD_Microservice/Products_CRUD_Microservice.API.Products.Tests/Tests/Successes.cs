using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Utils;

namespace Products_CRUD_Microservice.API.Products.Tests.Tests
{
    public class Successes : UnitTest
    {
        [Test]
        public void GetById()
        {
            ApiResponse<ProductDTO> response = new RestClient<ApiResponse<ProductDTO>>("https://localhost:7046/api/v1.0/products/getById?id=1")
                .AddHeader("Accept", "application/json")
                .Execute();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }
    }
}