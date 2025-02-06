using AlmoxarifadoBackAPI.DTO;

namespace AlmoxarifadoBackAPI.Models
{
    public class Produtos
    {
       
        public int Id { get; set; }
        public string DescProduto { get; set; }
        public string UnidMedida { get; set; }
        public float EstoqueAtual { get; set; }
        public bool EPermamente { get; set; }
        public int Codigo { get; set; }

    }
}
