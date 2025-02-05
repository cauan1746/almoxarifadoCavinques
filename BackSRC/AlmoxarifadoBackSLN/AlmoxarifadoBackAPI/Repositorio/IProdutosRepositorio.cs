using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IProdutosRepositorio
    {
        void Add(Produtos produtos);

        List<Produtos> GetAll();

    }
}
