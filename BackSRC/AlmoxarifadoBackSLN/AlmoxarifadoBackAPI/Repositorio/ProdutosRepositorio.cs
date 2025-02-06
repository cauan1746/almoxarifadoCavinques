using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly Context _db;

        public ProdutosRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Produtos obj)
        {

            _db.Produtos.Add(obj);
            _db.SaveChanges();
        }

        public List<Produtos> GetAll()
        {
            return _db.Produtos.ToList();
        }

    }
}
