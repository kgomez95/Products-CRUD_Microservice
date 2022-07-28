﻿using AutoMapper;
using Products_CRUD_Microservice.Exceptions.StatusExceptions;
using Products_CRUD_Microservice.Models.Products.DAO;
using Products_CRUD_Microservice.Models.Products.DTO;
using Products_CRUD_Microservice.Repository.Products.Interfaces;
using Products_CRUD_Microservice.Services.Products.Interfaces;
using Products_CRUD_Microservice.Utils;

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
            Product? product = this._productRepository.GetById(id);

            if (product == null)
            {
                throw new NotFoundException(string.Format("El producto con id '{0}' no existe en nuestros sistemas.", id));
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        public virtual ProductDTO GetByName(string name)
        {
            Product? product = this._productRepository.GetByName(name);

            if (product == null)
            {
                throw new NotFoundException(string.Format("El producto con nombre '{0}' no existe en nuestros sistemas.", name));
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        public virtual ProductDTO[] GetAll(string? name, string? description, double? price, DateTime? createdAt, DateTime? updatedAt, bool? enabled)
        {
            Product[] products = this._productRepository.GetAll(name, description, price, createdAt, updatedAt, enabled);

            if (products == null)
            {
                throw new NotFoundException("Ha ocurrido un problema al intentar buscar los productos.");
            }

            return this._mapper.Map<ProductDTO[]>(products);
        }

        public virtual ProductDTO Create(ProductDTO recordDTO)
        {
            Product? product = this._productRepository.Create(this._mapper.Map<Product>(recordDTO));

            if (product == null)
            {
                throw new NotFoundException("No se ha podido crear el producto. Por favor, contacte con un administrador.");
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        public virtual ProductDTO Update(ProductDTO recordDTO)
        {
            Product? product = this._productRepository.Update(this._mapper.Map<Product>(recordDTO));

            if (product == null)
            {
                throw new NotFoundException("El producto que ha intentado actualizar no existe.");
            }

            return this._mapper.Map<ProductDTO>(product);
        }

        public virtual void Delete(int id)
        {
            bool isDeleted = this._productRepository.Delete(id);

            if (!isDeleted)
            {
                throw new NotFoundException("El producto que ha intentado borrar no existe.");
            }
        }
    }
}
