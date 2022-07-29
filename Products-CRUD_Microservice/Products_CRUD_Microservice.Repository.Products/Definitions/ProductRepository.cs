using Microsoft.Extensions.Logging;
using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Utils.Extensions;

namespace Products_CRUD_Microservice.Repository.Products.Definitions
{
    public class ProductRepository : IProductRepository
    {
        #region Private variables.
        private readonly ILogger<ProductRepository> _logger;
        #endregion

        #region Protected variables.
        protected readonly ProductContext _productContext;
        #endregion

        public ProductRepository(ProductContext productContext, ILogger<ProductRepository> logger)
        {
            this._logger = logger;
            this._productContext = productContext;
        }

        #region Members of IGetRepository.

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

        #endregion

        #region Members of ICreateRepository.

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

        #endregion

        #region Members of IUpdateRepository.

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
                this._logger.LogError(ex, "(ProductRepository -> Update) Record = {0}", (record != null) ? record.ToJSON() : "");
                throw ex;
            }
        }

        #endregion

        #region Members of IDeleteRepository.

        /// <summary>
        /// Borra de base de datos el producto proporcionado por parámetros.
        /// </summary>
        /// <param name="id">Identificador del producto a borrar.</param>
        /// <returns>Retorna "true" si el producto se borra correctamente o "false" en caso de que no se pueda borrar.</returns>
        public virtual bool Delete(int id)
        {
            try
            {
                Product? product = this.GetById(id);

                if (product != null)
                {
                    this._productContext.Products.Remove(product);
                    this._productContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> Delete) Id = {0}", id);
                throw ex;
            }

            return false;
        }

        #endregion

        #region Members of IProductRepository.

        /// <summary>
        /// Obtiene uno o varios productos filtrando por cualquiera de sus valores.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar.</param>
        /// <param name="description">Descripción del producto a buscar.</param>
        /// <param name="price">Precio del producto a buscar.</param>
        /// <param name="createdAt">Fecha de creación del producto a buscar.</param>
        /// <param name="updatedAt">Fecha de actualización del producto a buscar.</param>
        /// <param name="enabled">Producto activado o desactivado.</param>
        /// <returns>Retorna un listado de productos.</returns>
        public virtual Product[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled)
        {
            // NOTE: Lo normal sería que en vez de coger todos los productos directamente que los cogiera por bloques, es decir, de forma paginada.

            try
            {
                // NOTE: También sería una buena idea crear un modelo para recibir todos estos parámetros en un solo objeto y que en dicho objeto
                //       hubiese una función llamada "GetAllExpression" que sea para utilizarla en la cláusula "Where" (así nos ahorramos tenerla
                //       dentro de esta función del repositorio).

                Func<Product, bool> expression = (product) =>
                {
                    // Realizamos la comprobación de los filtros y las introducimos en un listado de booleans.
                    bool[] filters = new bool[]
                    {
                        (name != null) ? product.Name.Contains(name) : true,
                        (description != null) ? product.Description.Contains(description) : true,
                        (price.HasValue) ? product.Price == price : true,
                        (createdAt.HasValue) ? product.CreatedAt == createdAt.Value : true,
                        (updatedAt.HasValue) ? product.UpdatedAt == updatedAt.Value : true,
                        (enabled.HasValue) ? product.Enabled == enabled.Value : true
                    };

                    // El registro coincide con los filtros en caso de que no haya ningún "false" en el listado "filters".
                    return !filters.Contains(false);
                };

                Product[] products = this._productContext.Products.Where(expression).ToArray();
                return products;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "(ProductRepository -> GetAll) Name = '{0}'; Description = '{1}'; Price = '{2}'; CreatedAt = '{3}'; UpdatedAt = '{4}'; Enabled = '{5}'",
                    name ?? "", description ?? "", (price.HasValue) ? Convert.ToString(price) : "",
                    (createdAt.HasValue) ? Convert.ToString(createdAt.Value) : Convert.ToString(DateTime.MinValue),
                    (updatedAt.HasValue) ? Convert.ToString(updatedAt.Value) : Convert.ToString(DateTime.MinValue),
                    (enabled.HasValue) ? Convert.ToString(enabled.Value) : "");
                throw ex;
            }
        }

        #endregion
    }
}
