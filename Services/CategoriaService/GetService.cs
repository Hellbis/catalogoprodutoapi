using CatalogoProdutos.Models;
using CatalogoProdutos.Repositories;

namespace CatalogoProdutos.Services.CategoriaServices
{
    public class GetService
    {
        public Categoria Execute(int codigo)
        {
            return new CategoriaRepository().Get(codigo);
        }
    }
}
