using SimuladorCredito.Api.Models.Entidades;

namespace SimuladorCredito.Api.Servicos.Interfaces
{
    public interface ISegmentoServico
    {
        public Task<Segmento> ObterPorId(int id);
        public Task<List<Segmento>> ObterTodos();
        public Task Adicionar(Segmento segmento);
        public Task Atualizar(Segmento segmento);
        public Task Remover(int id);
    }
}
