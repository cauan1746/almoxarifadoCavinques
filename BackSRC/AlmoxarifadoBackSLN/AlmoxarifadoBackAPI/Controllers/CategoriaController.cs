using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _db;
        public CategoriaController(ICategoriaRepositorio db)
        {
            _db = db;
        }
      
        

        [HttpGet("/listacategoria")]
        public IActionResult listaCategorias()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/categoria")]
        public IActionResult listaCategorias(CategoriaDTO categoria)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==categoria.Codigo));
        }

        [HttpPost("/criarcategoria")]
        public IActionResult criarCategoria(CategoriaCadastroDTO categoria)
        {

            var novaCategoria = new Categoria()
            {               
                Descricao = categoria.Descricao
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaCategoria);
            return Ok("Cadastro com Sucesso");
        }

        //[HttpDelete("/removercategoria")]
        //public IActionResult removerCategorias(CategoriaDTO categoria)
        //{
        //    var itemPesquisado = _categorias.FirstOrDefault(x => x.Codigo == categoria.Codigo);

        //    if (itemPesquisado != null)
        //    {
        //        _categorias.Remove(itemPesquisado);
        //        return Ok("Removido com sucesso");
        //    }
        //    else
        //    {
        //        return Ok("Produdo não localizado");
        //    }

            
        //}



    }
}
