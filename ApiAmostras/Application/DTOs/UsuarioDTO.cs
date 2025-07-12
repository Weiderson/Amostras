using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ApiAmostras.Application.DTOs
{
    public class UsuarioDTO
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