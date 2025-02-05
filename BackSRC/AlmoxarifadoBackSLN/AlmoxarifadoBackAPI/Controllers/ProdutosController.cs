using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _db;
        private object produtos;

        public ProdutosController(IProdutosRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/lista")]
        public IActionResult listaProdutos()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/produtos")]
        public IActionResult listaProdutos(ProdutosDTO produtos)
        {
            return Ok(_db.GetAll().Where(x => x.Id == produtos.Id));
        }

        //[HttpPost("/addprodutos")]
        //public IActionResult criarCategoria(CategoriaCadastroDTO categoria)
        //{

        //    var novaCategoria = new Categoria()
        //    {
        //        Descricao = categoria.Descricao
        //    };
        //    //_categorias.Add(novaCategoria);
        //    _db.Add(novaCategoria);
        //    return Ok("Cadastro com Sucesso");
        //}
    }
}
