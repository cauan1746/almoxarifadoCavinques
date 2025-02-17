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
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaRepositorio _db;
        private object entrada;

        public EntradaController(IEntradaRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listaentrada")]
        public IActionResult listaEntrada()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Entrada")]
        public IActionResult listaEntrada(EntradaDTO entrada)
        {
            return Ok(_db.GetAll().Where(x => x.IdEnt == entrada.IdEnt));
        }

        [HttpPost("/addEntrada")]
        public IActionResult addEntrada(EntradaCadastroDTO entrada)
        {

            var novaEntrada = new Entrada()
            {
               IdForn = entrada.IdForn,
               DataEnt = entrada.DataEnt,
               Observação = entrada.Observação
               
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaEntrada);
            return Ok("Cadastro com Sucesso");
        }
    }
}
