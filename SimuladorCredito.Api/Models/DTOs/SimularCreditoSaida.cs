namespace SimuladorCredito.Api.Models.DTOs
{
    /// <summary>
    /// DTO de saída para o resultado da simulação de crédito.
    /// </summary>
    public class SimularCreditoSaida
    {
        /// <summary>
        /// Nome do segmento relacionado à simulação.
        /// </summary>
        public string NomeSegmento { get; set; }

        /// <summary>
        /// Taxa de crédito calculada para a simulação.
        /// </summary>
        public decimal Taxa { get; set; }
    }
}
