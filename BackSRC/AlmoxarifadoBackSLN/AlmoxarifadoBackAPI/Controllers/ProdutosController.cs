using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _db;
        private object produtos;

        public ProdutosController(IProdutosRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listaprodutos")]
        public IActionResult listaProdutos()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/produtos")]
        public IActionResult listaProdutos(ProdutosDTO produtos)
        {
            return Ok(_db.GetAll().Where(x => x.Id == produtos.Id));
        }

        [HttpPost("/addprodutos")]
        public IActionResult criarProduto(ProdutosCadastroDTO produto)
        {

            var novoProduto = new Produtos()
            {
                DescProduto = produto.DescProduto,
                UnidMedida = produto.UnidMedida ,
                EstoqueAtual = produto.EstoqueAtual,
                EPermamente = produto.EPermamente,
                Codigo = produto.Codigo
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novoProduto);
            return Ok("Cadastro com Sucesso");
        }
    }
}
