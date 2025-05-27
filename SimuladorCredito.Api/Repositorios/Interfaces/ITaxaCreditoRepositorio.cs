using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;

namespace SimuladorCredito.Api.Repositorios.Interfaces
{
    public interface ITaxaCreditoRepositorio
    {
        Task<TaxaCredito?> ObterPorId(int id);
        Task<List<TaxaCredito>> ObterTodos();
        Task Adicionar(TaxaCredito taxaCredito);
        Task Atualizar(TaxaCredito taxaCredito);
        Task Remover(int id);
        Task<TaxaCredito?> ObterTaxaSimulacao(SimularCreditoEntrada simularCreditoEntrada);
    }
}
