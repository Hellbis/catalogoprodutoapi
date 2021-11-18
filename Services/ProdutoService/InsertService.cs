using CatalogoProdutos.Models;
using CatalogoProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services.ProdutoService
{
    public class InsertService
    {
        public void Execute(Produto produto)
        {
            new ProdutoRepository().Insert(produto);
        }
    }
}
