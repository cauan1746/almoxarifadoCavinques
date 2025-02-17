using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItensEntradaController : ControllerBase
    {
        private readonly IItensEntradaRepositorio _db;
        private object itensentrada;

        public ItensEntradaController(IItensEntradaRepositorio db)
        {
            _db = db;
        }



        [HttpGet("/listaitensentrada")]
        public IActionResult listaItensEntrada()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/ItensEntrada")]
        public IActionResult listaItensEntrada(ItensEntradaDTO itensentrada)
        {
            return Ok(_db.GetAll().Where(x => x.IdItensEnt == itensentrada.IdItensEnt));
        }

        [HttpPost("/addItensEntrada")]
        public IActionResult addItensEntrada(ItensEntradaCadastroDTO itensentrada)
        {

            var novoItensEntrada = new ItensEntrada()
            {
                Id = itensentrada.Id,
                IdEnt = itensentrada.IdEnt,
                Quantidade = itensentrada.Quantidade,
                Preco = itensentrada.Preco,
                Total = itensentrada.Total

            };
            //_categorias.Add(novaCategoria);
            _db.Add(novoItensEntrada);
            return Ok("Cadastro com Sucesso");
        }
    }
}
