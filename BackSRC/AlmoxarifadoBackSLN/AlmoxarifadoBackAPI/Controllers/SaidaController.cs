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
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaRepositorio _db;
        private object saida;

        public SaidaController(ISaidaRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listaSaida")]
        public IActionResult listaSaida()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Saida")]
        public IActionResult listaSaida(SaidaDTO saida)
        {
            return Ok(_db.GetAll().Where(x => x.IdSaida == saida.IdSaida));
        }

        [HttpPost("/addSaida")]
        public IActionResult addSaida(SaidaCadastroDTO saida)
        {

            var novaSaida = new Saida()
            {
                IdSec = saida.IdSec,
                DataSaida = saida.DataSaida,
                Observação = saida.Observação

            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaSaida);
            return Ok("Cadastro com Sucesso");
        }
    }
}
