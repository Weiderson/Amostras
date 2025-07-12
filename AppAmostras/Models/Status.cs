using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAmostras.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
             
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O descrição deve no máximo 50 caracteres")]
        public string Descricao { get; set; } = null!;

        [NotMapped]
        public string DescricaoSalvo { get; set; }
    }
}
