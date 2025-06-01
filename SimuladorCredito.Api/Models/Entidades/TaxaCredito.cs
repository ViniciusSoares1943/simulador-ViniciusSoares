using SimuladorCredito.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Api.Models.Entidades
{
    /// <summary>
    /// Entidade que representa uma taxa de crédito.
    /// </summary>
    public class TaxaCredito
    {
        /// <summary>
        /// Identificador único da taxa de crédito.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Valor da taxa de crédito.
        /// </summary>
        public decimal Taxa { get; set; }

        /// <summary>
        /// Tipo de pessoa associada à taxa de crédito.
        /// </summary>
        public TipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Modalidade da taxa de crédito.
        /// </summary>
        public Modalidade Modalidade { get; set; }

        /// <summary>
        /// Produto relacionado à taxa de crédito.
        /// </summary>
        public Produto Produto { get; set; }

        /// <summary>
        /// Identificador do produto relacionado.
        /// </summary>
        public int ProdutoId { get; set; }

        /// <summary>
        /// Segmento relacionado à taxa de crédito.
        /// </summary>
        public Segmento Segmento { get; set; }

        /// <summary>
        /// Identificador do segmento relacionado.
        /// </summary>
        public int SegmentoId { get; set; }

        /// <summary>
        /// Data de cadastro da taxa de crédito.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Indica se a taxa de crédito está ativa.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data da última alteração da taxa de crédito.
        /// </summary>
        public DateTime DataAlteracao { get; set; }
    }
}
