using System.ComponentModel;

namespace SimuladorCredito.Api.Models.Enums
{
    /// <summary>
    /// Tipo Pessoa Física 1 ou Jurídica 2
    /// </summary>
    public enum TipoPessoa
    {
        [Description("Pessoa física")]
        PessoaFisica = 1,
        [Description("Pessoa jurídica")]
        PessoaJuridica = 2
    }
}
