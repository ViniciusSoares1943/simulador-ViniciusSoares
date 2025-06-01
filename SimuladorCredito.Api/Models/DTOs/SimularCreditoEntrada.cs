using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Models.DTOs
{
    /// <summary>
    /// DTO de entrada para simulação de crédito.
    /// </summary>
    public class SimularCreditoEntrada
    {
        /// <summary>
        /// Tipo de pessoa (física ou jurídica).
        /// </summary>
        public TipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Modalidade da simulação de crédito.
        /// </summary>
        public Modalidade Modalidade { get; set; }

        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public int ProdutoId { get; set; }

        /// <summary>
        /// Renda informada para a simulação.
        /// </summary>
        public decimal Renda { get; set; }
    }
}
