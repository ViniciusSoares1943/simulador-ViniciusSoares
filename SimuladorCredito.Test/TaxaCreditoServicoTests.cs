using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos;
using SimuladorCredito.Api.Servicos.Interfaces;
using Xunit;

namespace SimuladorCredito.Test
{
    public class TaxaCreditoServicoTests
    {
        private readonly Mock<ITaxaCreditoRepositorio> _taxaCreditoRepositorioMock;
        private readonly Mock<IProdutoServico> _produtoServicoMock;
        private readonly Mock<ISegmentoServico> _segmentoServicoMock;
        private readonly TaxaCreditoServico _taxaCreditoServico;

        public TaxaCreditoServicoTests()
        {
            _taxaCreditoRepositorioMock = new Mock<ITaxaCreditoRepositorio>();
            _produtoServicoMock = new Mock<IProdutoServico>();
            _segmentoServicoMock = new Mock<ISegmentoServico>();
            _taxaCreditoServico = new TaxaCreditoServico(
                _taxaCreditoRepositorioMock.Object,
                _produtoServicoMock.Object,
                _segmentoServicoMock.Object);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarTaxaCredito_QuandoEncontrada()
        {
            var taxa = new TaxaCredito 
            { 
                Id = 1,
                Taxa = 0.1m,
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                SegmentoId = 1,
                DataCadastro = DateTime.Now,
                Ativo = true,
                DataAlteracao = DateTime.Now
            };
            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync(taxa);

            var resultado = await _taxaCreditoServico.ObterPorId(1);

            Assert.Equal(taxa, resultado);
        }

        [Fact]
        public async Task ObterPorId_DeveLancarExcecao_QuandoNaoEncontrada()
        {
            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync((TaxaCredito)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.ObterPorId(1));
            Assert.Equal("Taxa de crédito com Id 1 não encontrada.", ex.Message);
        }

        [Fact]
        public async Task ObterTodos_DeveRetornarListaDeTaxas()
        {
            var lista = new List<TaxaCredito>
            {
                new TaxaCredito 
                { 
                    Id = 1, 
                    Taxa = 0.1m, 
                    TipoPessoa = TipoPessoa.PessoaFisica, 
                    Modalidade = Modalidade.PreFixado, 
                    ProdutoId = 1, 
                    SegmentoId = 1, 
                    DataCadastro = DateTime.Now, 
                    Ativo = true, 
                    DataAlteracao = DateTime.Now 
                }
            };
            _taxaCreditoRepositorioMock.Setup(r => r.ObterTodosInclude()).ReturnsAsync(lista);

            var resultado = await _taxaCreditoServico.ObterTodos();

            Assert.Single(resultado);
            Assert.Equal(lista[0], resultado[0]);
        }

        [Fact]
        public async Task ObterTaxaSimulacao_DeveRetornarSimularCreditoSaida_QuandoEncontrada()
        {
            var entrada = new SimularCreditoEntrada
            {
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                Renda = 2000
            };
            var segmento = new Segmento 
            { 
                Id = 2, 
                Nome = "Segmento Teste" 
            };
            var taxa = new TaxaCredito 
            { 
                Id = 1, 
                Taxa = 0.15m, 
                Segmento = segmento 
            };

            _taxaCreditoRepositorioMock.Setup(r => r.ObterTaxaSimulacao(entrada)).ReturnsAsync(taxa);

            var resultado = await _taxaCreditoServico.ObterTaxaSimulacao(entrada);

            Assert.Equal("Segmento Teste", resultado.NomeSegmento);
            Assert.Equal(0.15m, resultado.Taxa);
        }

        [Fact]
        public async Task ObterTaxaSimulacao_DeveLancarExcecao_QuandoNaoEncontrada()
        {
            var entrada = new SimularCreditoEntrada
            {
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                Renda = 2000
            };
            _taxaCreditoRepositorioMock.Setup(r => r.ObterTaxaSimulacao(entrada)).ReturnsAsync((TaxaCredito)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.ObterTaxaSimulacao(entrada));
            Assert.Equal("Taxa de crédito não encontrada.", ex.Message);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarTaxaCredito_QuandoValida()
        {
            var taxa = new TaxaCredito 
            { 
                Taxa = 0.2m,
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                SegmentoId = 1
            };
            _taxaCreditoRepositorioMock.Setup(r => r.Adicionar(It.IsAny<TaxaCredito>())).Returns(Task.CompletedTask);

            await _taxaCreditoServico.Adicionar(taxa);

            _taxaCreditoRepositorioMock.Verify(r => r.Adicionar(It.Is<TaxaCredito>(t =>
                t.Taxa == 0.2m &&
                t.TipoPessoa == TipoPessoa.PessoaFisica &&
                t.Modalidade == Modalidade.PreFixado &&
                t.Ativo == true
            )), Times.Once);
        }

        [Fact]
        public async Task Adicionar_DeveLancarExcecao_QuandoTaxaCreditoNula()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.Adicionar(null));
            Assert.Equal("Taxa de crédito não pode ser nula.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveAtualizarTaxaCredito_QuandoValida()
        {
            var taxa = new TaxaCredito
            {
                Id = 5,
                Taxa = 0.3m,
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 2,
                SegmentoId = 3,
                Ativo = true
            };
            var existente = new TaxaCredito
            {
                Id = 5,
                Taxa = 0.1m,
                TipoPessoa = TipoPessoa.PessoaJuridica,
                Modalidade = Modalidade.PosFixado,
                ProdutoId = 1,
                SegmentoId = 1,
                Produto = new Produto { Id = 1 },
                Segmento = new Segmento { Id = 1 },
                Ativo = false,
                DataAlteracao = DateTime.MinValue
            };

            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(5)).ReturnsAsync(existente);
            _taxaCreditoRepositorioMock.Setup(r => r.Atualizar(It.IsAny<TaxaCredito>())).Returns(Task.CompletedTask);

            _produtoServicoMock.Setup(p => p.ObterPorId(2)).ReturnsAsync(new Produto { Id = 2 });
            _segmentoServicoMock.Setup(s => s.ObterPorId(3)).ReturnsAsync(new Segmento { Id = 3 });

            typeof(TaxaCreditoServico).GetField("_produtoServico", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(_taxaCreditoServico, _produtoServicoMock.Object);
            typeof(TaxaCreditoServico).GetField("_segmentoServico", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(_taxaCreditoServico, _segmentoServicoMock.Object);

            await _taxaCreditoServico.Atualizar(taxa);

            _taxaCreditoRepositorioMock.Verify(r => r.Atualizar(It.IsAny<TaxaCredito>()), Times.Once);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoTaxaCreditoNula()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.Atualizar(null));
            Assert.Equal("Taxa de crédito não pode ser nula.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoTaxaCreditoNaoExiste()
        {
            var taxa = new TaxaCredito 
            { 
                Id = 10,
                Taxa = 0.5m,
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                SegmentoId = 1
            };
            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(10)).ReturnsAsync((TaxaCredito)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.Atualizar(taxa));
            Assert.Equal("Taxa de crédito com Id 10 não encontrada.", ex.Message);
        }

        [Fact]
        public async Task Remover_DeveRemoverTaxaCredito_QuandoExiste()
        {
            var taxa = new TaxaCredito 
            { 
                Id = 7,
                Taxa = 0.2m,
                TipoPessoa = TipoPessoa.PessoaFisica,
                Modalidade = Modalidade.PreFixado,
                ProdutoId = 1,
                SegmentoId = 1
            };
            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(7)).ReturnsAsync(taxa);
            _taxaCreditoRepositorioMock.Setup(r => r.Remover(7)).Returns(Task.CompletedTask);

            await _taxaCreditoServico.Remover(7);

            _taxaCreditoRepositorioMock.Verify(r => r.Remover(7), Times.Once);
        }

        [Fact]
        public async Task Remover_DeveLancarExcecao_QuandoTaxaCreditoNaoExiste()
        {
            _taxaCreditoRepositorioMock.Setup(r => r.ObterPorId(8)).ReturnsAsync((TaxaCredito)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _taxaCreditoServico.Remover(8));
            Assert.Equal("Taxa de crédito com Id 8 não encontrada.", ex.Message);
        }
    }
}
