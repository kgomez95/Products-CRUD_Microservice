using Microsoft.Extensions.Logging;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Utils.Extensions;

namespace Products_CRUD_Microservice.Repository.Products.Definitions
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        protected readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext, ILogger<ProductRepository> logger)
        {
            this._logger = logger;
            this._productContext = productContext;
        }

        /// <summary>
        /// Obtiene un producto mediante su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto a buscar.</param>
        /// <returns>Retorna un producto o NULL en caso de que el producto no exista.</returns>
        public virtual Product? GetById(int id)
        {
            try
            {
                Product? product = this._productContext.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> GetById) Id = {0}", id);
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un producto mediante su nombre.
        /// </summary>
        /// <param name="id">Nombre del producto a buscar.</param>
        /// <returns>Retorna un producto o NULL en caso de que el producto no exista.</returns>
        public virtual Product? GetByName(string name)
        {
            try
            {
                Product? product = this._productContext.Products.FirstOrDefault(x => x.Name.Equals(name));
                return product;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> GetByName) Name = {0}", name ?? "");
                throw ex;
            }
        }

        /// <summary>
        /// Crea el producto proporcionado por parámetros en base de datos.
        /// </summary>
        /// <param name="record">Producto a crear.</param>
        /// <returns>Retorna el producto que se ha creado con su identificador.</returns>
        public virtual Product? Create(Product record)
        {
            try
            {
                this._productContext.Products.Add(record);
                this._productContext.SaveChanges();
                return record;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> Create) Record = {0}", (record != null) ? record.ToJSON() : "");
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza en base de datos el producto proporcionado por parámetros.
        /// </summary>
        /// <param name="record">Producto a actualizar.</param>
        /// <returns>Retorna el producto actualizado o NULL en caso de que no exista.</returns>
        public virtual Product? Update(Product record)
        {
            try
            {
                // Buscamos el producto a modificar.
                Product? product = this.GetById(record.Id);

                if (product == null)
                {
                    //throw new NotFoundException()
                    return null;
                }

                // Actualizamos el producto y guardamos los cambios.
                product.Name = record.Name;
                product.Description = record.Description;
                product.Price = record.Price;
                product.Enabled = record.Enabled;
                this._productContext.SaveChanges();

                return product;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> Create) Record = {0}", (record != null) ? record.ToJSON() : "");
                throw ex;
            }
        }
    }
}
