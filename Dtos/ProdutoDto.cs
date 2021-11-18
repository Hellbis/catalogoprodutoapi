using CatalogoProdutos.Models;
using System.Collections.Generic;

namespace CatalogoProdutos.Dtos
{
    public class ProdutoDto
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPerPage { get; set; }
        public int TotalItems { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
