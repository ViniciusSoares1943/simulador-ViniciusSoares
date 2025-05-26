using SimuladorCredito.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Api.Models.Entidades
{
    public class Segmento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
