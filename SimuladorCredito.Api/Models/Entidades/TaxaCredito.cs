using SimuladorCredito.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Api.Models.Entidades
{
    public class TaxaCredito
    {
        [Key]
        public int Id { get; set; }
        public decimal Taxa { get; set; }
        public Produto Produto { get; set; }
        public Segmento Segmento { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
