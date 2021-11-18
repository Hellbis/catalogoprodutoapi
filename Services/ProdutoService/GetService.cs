using CatalogoProdutos.Dtos;
using CatalogoProdutos.Filter;
using CatalogoProdutos.Repositories;
using System.Collections.Generic;

namespace CatalogoProdutos.Services.ProdutoServices
{
    public class GetService
    {
        public ProdutoDto Execute(ProdutoFilter filter)
        {
            if (filter.Page > 0)
                filter.Page--;
            if (filter.TotalPerPage == 0)
                filter.TotalPerPage = 10;
            return new ProdutoRepository().Get(filter);
        }
    }
}
