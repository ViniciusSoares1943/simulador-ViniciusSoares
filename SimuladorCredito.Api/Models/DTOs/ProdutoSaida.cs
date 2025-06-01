using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Models.DTOs
{
    /// <summary>
    /// DTO de retorno para informações do produto.
    /// </summary>
    public class ProdutoSaida
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public int ProdutoId { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo de pessoa associada ao produto.
        /// </summary>
        public TipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Data de cadastro do produto.
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}
