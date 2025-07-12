using ApiAmostras.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace ApiAmostras.Application.DTOs
{
    public class AmostraDTO
    {      
        public int Id { get; set; }

        [MinLength(7, ErrorMessage = "O código da amostra deve ter 7 caracteres")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "O código da amostra deve conter apenas letras maiúsculas e números")]
        public string Codigo { get; set; } = null!;

        [MinLength(10, ErrorMessage = "A descrição deve ter pelo menos 10 caracteres")]
        [MaxLength(150, ErrorMessage = "A descrição deve no máximo 150 caracteres")]
        public string Descricao { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataRecebimento { get; set; } = DateTime.Now;

        public int StatusId { get; set; }        
       
    }
}
