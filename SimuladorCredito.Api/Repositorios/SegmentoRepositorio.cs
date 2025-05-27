using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Repositorios.Interfaces;

namespace SimuladorCredito.Api.Repositorios
{
    public class SegmentoRepositorio : RepositorioBase<Segmento>, ISegmentoRepositorio
    {
        public SegmentoRepositorio(DbContextClass context) : base(context)
        {
        }
    }
}
