using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAmostras.Domain.Model
{   
    public class Status
    {       
        public int Id { get; set; }
             
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O descrição deve no máximo 50 caracteres")]
        public string Descricao { get; set; } = null!;     
    }
}
