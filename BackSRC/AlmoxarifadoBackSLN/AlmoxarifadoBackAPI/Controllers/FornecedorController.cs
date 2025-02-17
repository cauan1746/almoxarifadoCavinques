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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _db;
        private object fornecedor;

        public FornecedorController(IFornecedorRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listafornecedor")]
        public IActionResult listaFornecedor()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/fornecedor")]
        public IActionResult listaFornecedor(FornecedorDTO fornecedor)
        {
            return Ok(_db.GetAll().Where(x => x.IdForn == fornecedor.IdForn));
        }

        [HttpPost("/addfornecedor")]
        public IActionResult addFornecedor(FornecedorCadastroDTO fornecedor)
        {

            var novoFornecedor = new Fornecedor()
            {
                NomeForn = fornecedor.NomeForn,
                EndereçoForn = fornecedor.EndereçoForn,
                Bairro = fornecedor.Bairro,
                Cidade= fornecedor.Cidade,
                EstadoSigla= fornecedor.EstadoSigla,
                Telefone= fornecedor.Telefone,
                CNPJ= fornecedor.CNPJ
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novoFornecedor);
            return Ok("Cadastro com Sucesso");
        }
    }
}

