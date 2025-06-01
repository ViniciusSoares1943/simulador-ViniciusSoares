using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Servicos
{
    public class TaxaCreditoServico : ITaxaCreditoServico
    {
        private readonly ITaxaCreditoRepositorio _taxaCreditoRepositorio;
        private readonly IProdutoServico _produtoServico;
        private readonly ISegmentoServico _segmentoServico;

        public TaxaCreditoServico(ITaxaCreditoRepositorio taxaCreditoRepositorio)
        {
            _taxaCreditoRepositorio = taxaCreditoRepositorio;
        }

        public async Task<TaxaCredito> ObterPorId(int id)
        {
            var taxaCredito = await _taxaCreditoRepositorio.ObterPorId(id);
            if (taxaCredito == null)
                throw new Exception($"Taxa de crédito com Id {id} não encontrada.");
            return taxaCredito;
        }

        public async Task<SimularCreditoSaida> ObterTaxaSimulacao(SimularCreditoEntrada simularCreditoEntrada)
        {
            var taxaCredito = await _taxaCreditoRepositorio.ObterTaxaSimulacao(simularCreditoEntrada);
            if (taxaCredito == null)
                throw new Exception($"Taxa de crédito não encontrada.");


            return new SimularCreditoSaida()
            {
                NomeSegmento = taxaCredito.Segmento.Nome,
                Taxa = taxaCredito.Taxa
            };
        }

        public async Task<List<TaxaCredito>> ObterTodos()
        {
            return await _taxaCreditoRepositorio.ObterTodosInclude();
        }

        public async Task Adicionar(TaxaCredito taxaCredito)
        {
            if (taxaCredito == null)
                throw new Exception("Taxa de crédito não pode ser nula.");

            taxaCredito.DataCadastro = DateTime.Now;
            taxaCredito.DataAlteracao = DateTime.Now;
            taxaCredito.Ativo = true;

            await _taxaCreditoRepositorio.Adicionar(taxaCredito);
        }

        public async Task Atualizar(TaxaCredito taxaCredito)
        {
            if (taxaCredito == null)
                throw new Exception("Taxa de crédito não pode ser nula.");

            var existente = await _taxaCreditoRepositorio.ObterPorId(taxaCredito.Id);
            if (existente == null)
                throw new Exception($"Taxa de crédito com Id {taxaCredito.Id} não encontrada.");

            if (taxaCredito.ProdutoId != existente.ProdutoId)
            {
                var produto = await _produtoServico.ObterPorId(taxaCredito.ProdutoId);
                existente.Produto = produto;
                existente.ProdutoId = produto.Id;
            }

            if (taxaCredito.SegmentoId != existente.SegmentoId)
            {
                var segmento = await _segmentoServico.ObterPorId(taxaCredito.SegmentoId);
                existente.Segmento = segmento;
                existente.SegmentoId = segmento.Id;
            }

            existente.DataAlteracao = DateTime.Now;
            existente.Taxa = taxaCredito.Taxa;
            existente.TipoPessoa = taxaCredito.TipoPessoa;
            existente.Modalidade = taxaCredito.Modalidade;
            existente.Ativo = taxaCredito.Ativo;

            await _taxaCreditoRepositorio.Atualizar(taxaCredito);
        }

        public async Task Remover(int id)
        {
            var existente = await _taxaCreditoRepositorio.ObterPorId(id);
            if (existente == null)
                throw new Exception($"Taxa de crédito com Id {id} não encontrada.");

            await _taxaCreditoRepositorio.Remover(id);
        }
    }
}
