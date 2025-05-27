using SimuladorCredito.Api.Models.Entidades;

namespace SimuladorCredito.Api.Repositorios.Interfaces
{
    public interface ISegmentoRepositorio
    {
        Task<Segmento?> ObterPorId(int id);
        Task<List<Segmento>> ObterTodos();
        Task Adicionar(Segmento segmento);
        Task Atualizar(Segmento segmento);
        Task Remover(int id);
    }
}
