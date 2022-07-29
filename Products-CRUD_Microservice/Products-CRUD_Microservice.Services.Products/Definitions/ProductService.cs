using AutoMapper;
using Products_CRUD_Microservice.Exceptions.StatusExceptions;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Services.Products.Interfaces;

namespace Products_CRUD_Microservice.Services.Products.Definitions
{
    public class ProductService : IProductService
    {
        #region Protected variables.

        protected readonly IMapper _mapper;
        protected readonly IProductRepository _productRepository;

        #endregion

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        #region Members of IGetService.

        /// <summary>
        /// Llama al repositorio para recuperar un producto filtrando por su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>Retorna el producto que se ha encontrado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún producto.</exception>
        public virtual ProductDTO GetById(int id)
        {
            Product? product = this._productRepository.GetById(id);

            if (product == null)
            {
                throw new NotFoundException(string.Format("El producto con id '{0}' no existe en nuestros sistemas.", id));
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        /// <summary>
        /// Llama al repositorio para recuperar un producto filtrando por su nombre.
        /// </summary>
        /// <param name="name">Nombre del producto.</param>
        /// <returns>Retorna el producto que se ha encontrado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún producto.</exception>
        public virtual ProductDTO GetByName(string name)
        {
            Product? product = this._productRepository.GetByName(name);

            if (product == null)
            {
                throw new NotFoundException(string.Format("El producto con nombre '{0}' no existe en nuestros sistemas.", name));
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        #endregion

        #region Members of ICreateService.

        /// <summary>
        /// Llama al repositorio para crear un producto.
        /// </summary>
        /// <param name="recordDTO">Producto a crear.</param>
        /// <returns>Retorna el producto que se ha creado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún producto.</exception>
        public virtual ProductDTO Create(ProductDTO recordDTO)
        {
            Product? product = this._productRepository.Create(this._mapper.Map<Product>(recordDTO));

            if (product == null)
            {
                throw new NotFoundException("No se ha podido crear el producto. Por favor, contacte con un administrador.");
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        #endregion

        #region Members of IUpdateService.

        /// <summary>
        /// Llama al repositorio para actualizar un producto.
        /// </summary>
        /// <param name="recordDTO">Producto a actualizar.</param>
        /// <returns>Retorna el producto que se ha actualizado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún producto.</exception>
        public virtual ProductDTO Update(ProductDTO recordDTO)
        {
            Product? product = this._productRepository.Update(this._mapper.Map<Product>(recordDTO));

            if (product == null)
            {
                throw new NotFoundException("El producto que ha intentado actualizar no existe.");
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        #endregion

        #region Members of IDeleteService.

        /// <summary>
        /// Llama al repositorio para borrar un producto.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no ha encontrado ningún producto para borrarlo.</exception>
        public virtual void Delete(int id)
        {
            bool isDeleted = this._productRepository.Delete(id);

            if (!isDeleted)
            {
                throw new NotFoundException("El producto que ha intentado borrar no existe.");
            }
        }

        #endregion

        #region Members of IProductService.

        /// <summary>
        /// Llama al repositorio para recuperar un listado de productos, pudiendo filtrar también por cualquiera de sus campos.
        /// </summary>
        /// <param name="name">Nombre del producto.</param>
        /// <param name="description">Descripción del producto.</param>
        /// <param name="price">Precio del producto.</param>
        /// <param name="createdAt">Fecha de creación del producto.</param>
        /// <param name="updatedAt">Fecha de actualización del producto.</param>
        /// <param name="enabled">Producto activado o desactivado.</param>
        /// <returns>Retorna el listado de productos que se ha encontrado en el repositorio.</returns>
        /// <exception cref="NotFoundException">Se lanza la excepción si el repositorio no devuelve ningún listado de productos.</exception>
        public virtual ProductDTO[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled)
        {
            Product[] products = this._productRepository.GetAll(name, description, price, createdAt, updatedAt, enabled);

            if (products == null)
            {
                throw new NotFoundException("Ha ocurrido un problema al intentar buscar los productos.");
            }

            return this._mapper.Map<ProductDTO[]>(products);
        }

        #endregion
    }
}
