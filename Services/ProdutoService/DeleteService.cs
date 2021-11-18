using CatalogoProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services.ProdutoService
{
    public class DeleteService
    {
        public void Execute(int codigo)
        {
            new ProdutoRepository().Delete(codigo);
        }
    }
}
