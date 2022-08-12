using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Models.Products.DTO;

namespace Products_CRUD_Microservice.API.Products.Tests.Tests
{
    public class Errors : UnitTest
    {
        #region GetById.

        [Test]
        public void GetById_400()
        {
            ApiResponse<ProductDTO> response = base.GetProductById("SimularError");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void GetById_404()
        {
            ApiResponse<ProductDTO> response = base.GetProductById(0);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(404));
        }

        #endregion

        #region GetByName.

        [Test]
        public void GetByName_400()
        {
            ApiResponse<ProductDTO> response = base.GetProductByName("");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void GetByName_404()
        {
            ApiResponse<ProductDTO> response = base.GetProductByName("MeLoInvento");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(404));
        }

        #endregion

        #region Create.

        [Test]
        public void Create_400()
        {
            ProductDTO productDTO = new ProductDTO()
            {
                Description = "Descripción 666",
                Price = 666.69,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            ApiResponse<ProductDTO> response = base.CreateProduct(productDTO);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(400));
        }

        #endregion

        #region Update.

        [Test]
        public void Update_400()
        {
            ProductDTO productDTO = new ProductDTO()
            {
                Id = 0,
                Description = "Descripción 666",
                Price = 666.69,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            ApiResponse<ProductDTO> response = base.UpdateProduct(productDTO);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void Update_404()
        {
            ProductDTO productDTO = new ProductDTO()
            {
                Id = 0,
                Name = "Prueba666",
                Description = "Descripción 666",
                Price = 666.69,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            ApiResponse<ProductDTO> response = base.UpdateProduct(productDTO);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(404));
        }

        #endregion

        #region Delete.

        [Test]
        public void Delete_400()
        {
            ApiResponse<string> response = base.DeleteProduct("SimularError");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void Delete_404()
        {
            ApiResponse<string> response = base.DeleteProduct(0);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Errors);
            Assert.IsNull(response.Data);
            Assert.That(response.StatusCode, Is.EqualTo(404));
        }

        #endregion
    }
}
