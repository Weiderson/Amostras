using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAmostras.Domain.Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        public string? Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = string.Empty;

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}