using System.ComponentModel;

namespace SimuladorCredito.Api.Models.Enums
{
    /// <summary>
    /// Modalidade Pré-fixado 1 ou Pós-fixado 2
    /// </summary>
    public enum Modalidade
    {
        [Description("Pré-fixado")]
        PreFixado = 1,
        [Description("Pós-fixado")]
        PosFixado = 2
    }
}
