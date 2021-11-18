using CatalogoProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Filter
{
    public class ProdutoFilter
    {
        public int TotalPerPage { get; set; }
        public int Page { get; set; }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeFornecedor { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
