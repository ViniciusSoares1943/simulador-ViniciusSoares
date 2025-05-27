using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> ObterPorId(int id);
        Task<List<Produto>> ObterTodos();
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int id);
        Task<List<Produto>> ObterPorTipoPessoa(TipoPessoa tipoPessoa);
    }
}
