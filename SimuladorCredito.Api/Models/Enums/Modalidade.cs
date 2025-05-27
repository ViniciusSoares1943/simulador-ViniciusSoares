using System.ComponentModel;

namespace SimuladorCredito.Api.Models.Enums
{
    public enum Modalidade
    {
        [Description("Pré-fixado")]
        PreFixado = 1,
        [Description("Pós-fixado")]
        PosFixado = 2
    }
}
