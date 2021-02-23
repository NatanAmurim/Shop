using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "The caracter length must be between 3 and 60.")]
        [MinLength(3, ErrorMessage = "The caracter length must be between 3 and 60.")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "The caracter length must be between 0 and 1024.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "The price must be bigger than 0.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "The price must be ")]
        public int CategoryId { get; set; }

        public Category category { get; set; }

    }
}