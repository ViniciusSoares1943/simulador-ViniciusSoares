namespace SimuladorCredito.Api.Repositorios.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T?> ObterPorId(int id);
        Task<List<T>> ObterTodos();
        Task Adicionar(T entidade);
        Task Atualizar(T entidade);
        Task Remover(int id);
    }
}
