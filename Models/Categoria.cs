using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
