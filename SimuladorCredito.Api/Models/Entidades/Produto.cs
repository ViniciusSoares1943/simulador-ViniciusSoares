using SimuladorCredito.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Api.Models.Entidades
{
    /// <summary>
    /// Entidade que representa um produto.
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo de pessoa que pode vincular ao produto.
        /// </summary>
        public TipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Data de cadastro do produto.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Indica se o produto está ativo.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data da última alteração do produto.
        /// </summary>
        public DateTime DataAlteracao { get; set; }
    }
}
