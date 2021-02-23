using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "The caracter length must be between 3 and 60.")]
        [MinLength(3, ErrorMessage = "The caracter length must be between 3 and 60.")]
        public string Title { get; set; }
    }
}