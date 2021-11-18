using CatalogoProdutos.Context;
using CatalogoProdutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.Repositories
{
    public class CategoriaRepository
    {
        public CatalogoContext db = new CatalogoContext();

        public void Insert(Categoria categoria)
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            var c = db.Categorias.First(s => s.Codigo == categoria.Codigo);
            c.Nome = categoria.Nome;
            c.Status = categoria.Status;
            db.SaveChanges();
        }

        public Categoria Get(int codigo)
        {
            return db.Categorias.First(s => s.Codigo == codigo);
        }

        public void Delete(int codigo)
        {
            var c = db.Categorias.First(s => s.Codigo == codigo);
            c.Status = false;
            db.SaveChanges();
        }
    }
}
