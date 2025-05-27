using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Models.DTOs
{
    public class SimularCreditoEntrada
    {
        public TipoPessoa TipoPessoa { get; set; }
        public Modalidade Modalidade { get; set; }
        public int ProdutoId { get; set; }
        public decimal Renda { get; set; }
    }
}
