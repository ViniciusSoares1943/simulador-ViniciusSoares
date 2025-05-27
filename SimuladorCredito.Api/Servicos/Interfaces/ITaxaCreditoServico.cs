using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;

namespace SimuladorCredito.Api.Servicos.Interfaces
{
    public interface ITaxaCreditoServico
    {
        public Task<TaxaCredito> ObterPorId(int id);
        public Task<List<TaxaCredito>> ObterTodos();
        public Task Adicionar(TaxaCredito taxaCredito);
        public Task Atualizar(TaxaCredito taxaCredito);
        public Task Remover(int id);
        public Task<SimularCreditoSaida> ObterTaxaSimulacao(SimularCreditoEntrada simularCreditoEntrada);
    }
}
