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
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaRepositorio _db;
        private object secretaria;

        public SecretariaController(ISecretariaRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listasecretarias")]
        public IActionResult listaSecretaria()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/secretaria")]
        public IActionResult listaSecretaria(SecretariaDTO secretaria)
        {
            return Ok(_db.GetAll().Where(x => x.IdSec == secretaria.IdSec));
        }

        [HttpPost("/addSecretaria")]
        public IActionResult addSecretaria(SecretariaCadastroDTO secretaria)
        {

            var novaSecretaria = new Secretaria()
            {
                NomeSec = secretaria.NomeSec,
                EndereçoSec = secretaria.EndereçoSec,
                Bairro = secretaria.Bairro,
                Cidade = secretaria.Cidade,
                EstadoSigla = secretaria.EstadoSigla,
                Telefone = secretaria.Telefone,
                CNPJ = secretaria.CNPJ
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaSecretaria);
            return Ok("Cadastro com Sucesso");
        }
    }
}
