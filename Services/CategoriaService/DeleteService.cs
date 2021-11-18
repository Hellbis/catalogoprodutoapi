using CatalogoProdutos.Repositories;

namespace CatalogoProdutos.Services.CategoriaService
{
    public class DeleteService
    {
        public void Execute(int codigo)
        {
            new CategoriaRepository().Delete(codigo);
        }
    }
}
