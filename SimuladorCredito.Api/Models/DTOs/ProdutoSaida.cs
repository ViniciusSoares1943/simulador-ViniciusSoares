using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Models.DTOs
{
    public class ProdutoSaida
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
