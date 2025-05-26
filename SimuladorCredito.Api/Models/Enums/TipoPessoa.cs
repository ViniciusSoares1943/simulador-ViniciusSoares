using System.ComponentModel;

namespace SimuladorCredito.Api.Models.Enums
{
    public enum TipoPessoa
    {
        [Description("Pessoa física")]
        PessoaFisica = 1,
        [Description("Pessoa jurídica")]
        PessoaJuridica = 2
    }
}
