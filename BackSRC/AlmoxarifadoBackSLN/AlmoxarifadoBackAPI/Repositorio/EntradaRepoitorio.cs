using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class EntradaRepoitorio : IEntradaRepositorio
    {
        private readonly Context _db;

        public EntradaRepoitorio(Context db)
        {
            _db = db;
        }
         
        public void Add(Entrada obj)
        {

            _db.Entrada.Add(obj);
            _db.SaveChanges();
        }

        public List<Entrada> GetAll()
        {
            return _db.Entrada.ToList();
        }
    }
}
