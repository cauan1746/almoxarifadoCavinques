using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly Context _db;

        public ProdutosRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Produtos produtos)
        {

            _db.Produtos.Add(produtos);
            _db.SaveChanges();
        }

        public List<Produtos> GetAll()
        {
            return _db.Produtos.ToList();
        }

    }
}
