using CatalogoProdutos.Filter;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services.ProdutoServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] ProdutoFilter filter)
        {
            try
            {
                return Ok(new GetService().Execute(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
