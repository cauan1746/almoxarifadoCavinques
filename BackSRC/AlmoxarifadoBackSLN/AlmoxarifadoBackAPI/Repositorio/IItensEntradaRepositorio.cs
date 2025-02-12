using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IItensEntradaRepositorio
    {
        void Add(ItensEntrada itensentrada);

        List<ItensEntrada> GetAll();
    }
}
