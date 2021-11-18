using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string NomeFornecedor { get; set; }
        public int CodigoCategoria { get; set; }
        public double PrecoVenda { get; set; }
        [NotMapped]
        public Categoria Categoria { get; set; }
    }
}
