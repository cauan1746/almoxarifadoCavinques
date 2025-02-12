using AlmoxarifadoBackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class ItensEntradaRepositorio : IItensEntradaRepositorio
    {
        private readonly Context _db;

        public ItensEntradaRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(ItensEntrada obj)
        {

            _db.ItensEntrada.Add(obj);
            _db.SaveChanges();
        }

        public List<ItensEntrada> GetAll()
        {
            return _db.ItensEntrada.ToList();
        }
    }
}
