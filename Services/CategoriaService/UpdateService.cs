using CatalogoProdutos.Models;
using CatalogoProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services.CategoriaService
{
    public class UpdateService
    {
        public void Execute(Categoria categoria)
        {
            new CategoriaRepository().Update(categoria);
        }
    }
}
