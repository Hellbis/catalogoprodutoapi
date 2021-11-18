using CatalogoProdutos.Models;
using CatalogoProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services.ProdutoService
{
    public class UpdateService
    {
        public void Execute(Produto produto)
        {
            var produtoRepository = new ProdutoRepository();
            if(produtoRepository.Exists(produto.Codigo))
            {
                new ProdutoRepository().Update(produto);
            }
            else
            {
                new ProdutoRepository().Insert(produto);
            }
        }
    }
}
