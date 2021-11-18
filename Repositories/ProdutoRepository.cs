using CatalogoProdutos.Context;
using CatalogoProdutos.Dtos;
using CatalogoProdutos.Filter;
using CatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CatalogoProdutos.Repositories
{
    public class ProdutoRepository
    {
        public CatalogoContext db = new CatalogoContext();

        public ProdutoDto Get(ProdutoFilter filter)
        {
            var query = " SELECT * FROM public.\"Produtos\" ";
            query += $" ORDER BY \"Codigo\" OFFSET {filter.Page * filter.TotalPerPage} LIMIT {filter.TotalPerPage} ";

            var totalItems = db.Produtos.Count();
            var produtos = db.Produtos.FromSqlRaw(query).ToList();

            var categoriaRepository = new CategoriaRepository();

            produtos.ForEach(s =>
            {
                s.Categoria = categoriaRepository.Get(s.CodigoCategoria);
            });

            ProdutoDto produtoDto = new()
            {
                Produtos = produtos,
                TotalPages =  totalItems / filter.TotalPerPage,
                CurrentPage = filter.Page+1,
                TotalPerPage = filter.TotalPerPage,
                TotalItems = totalItems
            };

            return produtoDto;
        }

        public void Insert(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        public void Update(Produto produto)
        {
            var p = db.Produtos.First(s => s.Codigo == produto.Codigo);
            p.Descricao = produto.Descricao;
            p.NomeFornecedor = produto.NomeFornecedor;
            p.CodigoCategoria = produto.CodigoCategoria;
            p.PrecoVenda = produto.PrecoVenda;
            db.SaveChanges();
        }

        public void Delete(int codigo)
        {
            var p = db.Produtos.First(s => s.Codigo == codigo);
            if(p != null)
            {
                db.Produtos.Remove(p);
                db.SaveChanges();
            }
        }

        public bool Exists(int codigo)
        {
            return db.Produtos.Any(s => s.Codigo == codigo);
        }
    }
}
