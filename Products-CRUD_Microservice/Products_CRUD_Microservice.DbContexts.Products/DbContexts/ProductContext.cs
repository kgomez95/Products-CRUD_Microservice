using Microsoft.EntityFrameworkCore;
using Products_CRUD_Microservice.Constants.Products;
using Products_CRUD_Microservice.Models.Products.DAO;

namespace Products_CRUD_Microservice.DbContexts.Products.DbContexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.OnTableCreating_Products(modelBuilder);
        }

        /// <summary>
        /// Inicializa la tabla "PRODUCTS".
        /// </summary>
        /// <param name="modelBuilder">Parámetro necesario para configurar la tabla.</param>
        protected virtual void OnTableCreating_Products(ModelBuilder modelBuilder)
        {
            // Nombre de la tabla.
            modelBuilder.Entity<Product>().ToTable(ProductsValues.DbContext.TABLE_NAME);

            // Clave primaria.
            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            // Índices.
            modelBuilder.Entity<Product>().HasIndex(x => x.Id);
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Price);
            modelBuilder.Entity<Product>().HasIndex(x => x.Enabled);

            // Mapeo de campos.
            modelBuilder.Entity<Product>()
                .Property<int>(x => x.Id)
                .HasColumnName(ProductsValues.DbContext.Fields.ID);
            modelBuilder.Entity<Product>()
                .Property<string>(x => x.Name)
                .HasColumnName(ProductsValues.DbContext.Fields.NAME)
                .HasMaxLength(ProductsValues.DbContext.FieldsLength.NAME)
                .IsRequired(ProductsValues.DbContext.RequiredFields.NAME);
            modelBuilder.Entity<Product>()
                .Property<string>(x => x.Description)
                .HasColumnName(ProductsValues.DbContext.Fields.DESCRIPTION)
                .IsRequired(ProductsValues.DbContext.RequiredFields.DESCRIPTION)
                .HasColumnType(ProductsValues.DbContext.FieldsType.DESCRIPTION);
            modelBuilder.Entity<Product>()
                .Property<double>(x => x.Price)
                .HasColumnName(ProductsValues.DbContext.Fields.PRICE)
                .IsRequired(ProductsValues.DbContext.RequiredFields.PRICE)
                .HasColumnType(ProductsValues.DbContext.FieldsType.PRICE);
            modelBuilder.Entity<Product>()
                .Property<DateTime>(x => x.CreatedAt)
                .HasColumnName(ProductsValues.DbContext.Fields.CREATED_AT)
                .HasDefaultValueSql(ProductsValues.DbContext.FieldsDefaultValues.CREATED_AT);
            modelBuilder.Entity<Product>()
                .Property<DateTime>(x => x.UpdatedAt)
                .HasColumnName(ProductsValues.DbContext.Fields.UPDATED_AT)
                .HasDefaultValueSql(ProductsValues.DbContext.FieldsDefaultValues.UPDATED_AT);
            modelBuilder.Entity<Product>()
                .Property<bool>(x => x.Enabled)
                .HasColumnName(ProductsValues.DbContext.Fields.ENABLED)
                .IsRequired(ProductsValues.DbContext.RequiredFields.ENABLED);
        }
    }
}
