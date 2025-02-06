using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly Context _db;

        public CategoriaRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Categoria obj)
        {

            _db.Categoria.Add(obj);
            _db.SaveChanges();
        }

        public List<Categoria> GetAll() { 
          return _db.Categoria.ToList();
        }

    }
}
