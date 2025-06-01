using SimuladorCredito.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Api.Models.Entidades
{
    /// <summary>
    /// Entidade que representa um segmento.
    /// </summary>
    public class Segmento
    {
        /// <summary>
        /// Identificador único do segmento.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do segmento.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do segmento.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo de pessoa que pode vincular ao segmento.
        /// </summary>
        public TipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Renda mínima exigida para o segmento.
        /// </summary>
        public decimal RendaMinima { get; set; }

        /// <summary>
        /// Renda máxima permitida para o segmento.
        /// </summary>
        public decimal? RendaMaxima { get; set; }

        /// <summary>
        /// Data de cadastro do segmento.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Indica se o segmento está ativo.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data da última alteração do segmento.
        /// </summary>
        public DateTime DataAlteracao { get; set; }
    }
}
