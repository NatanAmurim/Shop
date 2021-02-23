using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(20, ErrorMessage = "The caracter length must be between 3 and 20.")]
        [MinLength(3, ErrorMessage = "The caracter length must be between 3 and 20.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(20, ErrorMessage = "The caracter length must be between 3 and 20.")]
        [MinLength(3, ErrorMessage = "The caracter length must be between 3 and 20.")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}