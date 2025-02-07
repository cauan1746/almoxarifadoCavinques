namespace AlmoxarifadoBackAPI.Models
{
    public class Fornecedor
    {
        public int IdForn { get; set; }
        public string NomeForn { get; set; }
        public string EndereçoForn { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string EstadoSigla { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
    }
}
