using CatalogoProdutos.Models;
using CatalogoProdutos.Repositories;
using System;

namespace CatalogoProdutos.Services.CategoriaService
{
    public class InsertService
    {
        public void Execute(Categoria categoria)
        {
            new CategoriaRepository().Insert(categoria);
        }
    }
}
