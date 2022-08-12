using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Models.Products.DTO;

namespace Products_CRUD_Microservice.API.Products.Tests.Tests
{
    public class Successes : UnitTest
    {
        [Test]
        public void GetById()
        {
            ApiResponse<ProductDTO> response = base.GetProductById(1);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetByName()
        {
            ApiResponse<ProductDTO> response = base.GetProductByName("Prueba1");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Create()
        {
            ProductDTO productDTO = new ProductDTO()
            {
                Name = "Prueba666",
                Description = "Descripción 666",
                Price = 666.69,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            ApiResponse<ProductDTO> response = base.CreateProduct(productDTO);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Data.Id, Is.AtLeast(1));
        }

        [Test]
        public void Update()
        {
            int productId = 3002;

            #region Obtain the product.

            ApiResponse<ProductDTO> response = base.GetProductById(productId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));

            #endregion

            #region Update the product.

            response.Data.Name = "Prueba777";
            response.Data.Description = "Descripción 777";
            response.Data.Price = 777.666;
            response.Data.Enabled = false;
            response.Data.UpdatedAt = DateTime.Now;

            response = base.UpdateProduct(response.Data);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Data.Id, Is.EqualTo(productId));
            Assert.That(response.Data.Name, Is.EqualTo("Prueba777"));
            Assert.That(response.Data.Description, Is.EqualTo("Descripción 777"));
            Assert.That(response.Data.Price, Is.EqualTo(777.666));
            Assert.That(response.Data.Enabled, Is.EqualTo(false));

            #endregion
        }

        [Test]
        public void Delete()
        {
            ApiResponse<string> response = base.DeleteProduct(3002);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }
    }
}