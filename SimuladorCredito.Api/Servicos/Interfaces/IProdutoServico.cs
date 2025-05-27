using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Servicos.Interfaces
{
    public interface IProdutoServico
    {
        public Task<Produto> ObterPorId(int id);
        public Task<List<Produto>> ObterTodos();
        public Task Adicionar(Produto produto);
        public Task Atualizar(Produto produto);
        public Task Remover(int id);
        public Task<List<Produto>> ObterPorTipoPessoa(TipoPessoa tipoPessoa);
    }
}
