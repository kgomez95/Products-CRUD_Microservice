using System.ComponentModel.DataAnnotations;

namespace Products_CRUD_Microservice.Models.Products.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'Name' es obligatorio."), MaxLength(50, ErrorMessage = "El campo 'Name' permite hasta un máximo de 50 caracteres.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }
}
