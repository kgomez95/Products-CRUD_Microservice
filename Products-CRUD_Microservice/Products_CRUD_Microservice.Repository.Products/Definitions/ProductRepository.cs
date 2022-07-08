using Products_CRUD_Microservice.DbContexts.Products.DbContexts;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;

namespace Products_CRUD_Microservice.Repository.Products.Definitions
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            this._productContext = productContext;
        }

        /// <summary>
        /// Obtiene un producto mediante su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto a buscar.</param>
        /// <returns>Retorna un producto o NULL en caso de que el producto no exista.</returns>
        public virtual Product GetById(int id)
        {
            try
            {
                Product product = this._productContext.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un producto mediante su nombre.
        /// </summary>
        /// <param name="id">Nombre del producto a buscar.</param>
        /// <returns>Retorna un producto o NULL en caso de que el producto no exista.</returns>
        public virtual Product GetByName(string name)
        {
            try
            {
                Product product = this._productContext.Products.FirstOrDefault(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Crea el producto proporcionado por parámetros en base de datos.
        /// </summary>
        /// <param name="record">Producto a crear.</param>
        /// <returns>Retorna el producto que se ha creado con su identificador.</returns>
        public virtual Product Create(Product record)
        {
            try
            {
                this._productContext.Products.Add(record);
                this._productContext.SaveChanges();
                return record;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
