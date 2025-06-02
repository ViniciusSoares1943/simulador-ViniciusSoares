using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos;
using Xunit;

namespace SimuladorCredito.Test
{
    public class SegmentoServicoTests
    {
        private readonly Mock<ISegmentoRepositorio> _segmentoRepositorioMock;
        private readonly SegmentoServico _segmentoServico;

        public SegmentoServicoTests()
        {
            _segmentoRepositorioMock = new Mock<ISegmentoRepositorio>();
            _segmentoServico = new SegmentoServico(_segmentoRepositorioMock.Object);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarSegmento_QuandoEncontrado()
        {
            var segmento = new Segmento
            {
                Id = 1,
                Nome = "Segmento Teste",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 1000,
                RendaMaxima = 5000,
                DataCadastro = DateTime.Now,
                Ativo = true,
                DataAlteracao = DateTime.Now
            };
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync(segmento);

            var resultado = await _segmentoServico.ObterPorId(1);

            Assert.Equal(segmento, resultado);
        }

        [Fact]
        public async Task ObterPorId_DeveLancarExcecao_QuandoNaoEncontrado()
        {
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync((Segmento)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.ObterPorId(1));
            Assert.Equal("Segmento com Id 1 não encontrado.", ex.Message);
        }

        [Fact]
        public async Task ObterTodos_DeveRetornarListaDeSegmentos()
        {
            var lista = new List<Segmento>
            {
                new Segmento
                {
                    Id = 1,
                    Nome = "Segmento Teste",
                    Descricao = "Desc",
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    RendaMinima = 1000,
                    RendaMaxima = 5000,
                    DataCadastro = DateTime.Now,
                    Ativo = true,
                    DataAlteracao = DateTime.Now
                }
            };
            _segmentoRepositorioMock.Setup(r => r.ObterTodos()).ReturnsAsync(lista);

            var resultado = await _segmentoServico.ObterTodos();

            Assert.Single(resultado);
            Assert.Equal(lista[0], resultado[0]);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarSegmento_QuandoValido()
        {
            var segmento = new Segmento
            {
                Nome = "Novo Segmento",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 1000,
                RendaMaxima = 5000
            };
            _segmentoRepositorioMock.Setup(r => r.Adicionar(It.IsAny<Segmento>())).Returns(Task.CompletedTask);

            await _segmentoServico.Adicionar(segmento);

            _segmentoRepositorioMock.Verify(r => r.Adicionar(It.Is<Segmento>(s =>
                s.Nome == "Novo Segmento" &&
                s.Descricao == "Desc" &&
                s.TipoPessoa == TipoPessoa.PessoaFisica &&
                s.Ativo == true
            )), Times.Once);
        }

        [Fact]
        public async Task Adicionar_DeveLancarExcecao_QuandoSegmentoNulo()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.Adicionar(null));
            Assert.Equal("Segmento não pode ser nulo.", ex.Message);
        }

        [Fact]
        public async Task Adicionar_DeveLancarExcecao_QuandoNomeVazio()
        {
            var segmento = new Segmento
            {
                Nome = "",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 1000,
                RendaMaxima = 5000
            };
            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.Adicionar(segmento));
            Assert.Equal("O nome do segmento é obrigatório.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveAtualizarSegmento_QuandoValido()
        {
            var segmento = new Segmento
            {
                Id = 5,
                Nome = "Atualizado",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 2000,
                RendaMaxima = 8000,
                Ativo = true
            };
            var existente = new Segmento
            {
                Id = 5,
                Nome = "Antigo",
                Descricao = "Antiga",
                TipoPessoa = TipoPessoa.PessoaJuridica,
                RendaMinima = 1000,
                RendaMaxima = 5000,
                Ativo = false,
                DataAlteracao = DateTime.MinValue
            };
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(5)).ReturnsAsync(existente);
            _segmentoRepositorioMock.Setup(r => r.Atualizar(It.IsAny<Segmento>())).Returns(Task.CompletedTask);

            await _segmentoServico.Atualizar(segmento);

            _segmentoRepositorioMock.Verify(r => r.Atualizar(It.Is<Segmento>(s =>
                s.Id == 5 &&
                s.Nome == "Atualizado" &&
                s.Descricao == "Desc" &&
                s.TipoPessoa == TipoPessoa.PessoaFisica &&
                s.RendaMinima == 2000 &&
                s.RendaMaxima == 8000 &&
                s.Ativo == true &&
                s.DataAlteracao > DateTime.MinValue
            )), Times.Once);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoSegmentoNulo()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.Atualizar(null));
            Assert.Equal("Segmento não pode ser nulo.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoSegmentoNaoExiste()
        {
            var segmento = new Segmento
            {
                Id = 10,
                Nome = "Segmento X",
                Descricao = "X Segmento",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 1000,
                RendaMaxima = 5000
            };
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(10)).ReturnsAsync((Segmento)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.Atualizar(segmento));
            Assert.Equal("Segmento com Id 10 não encontrado.", ex.Message);
        }

        [Fact]
        public async Task Remover_DeveRemoverSegmento_QuandoExiste()
        {
            var segmento = new Segmento
            {
                Id = 7,
                Nome = "Remover",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                RendaMinima = 1000,
                RendaMaxima = 5000
            };
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(7)).ReturnsAsync(segmento);
            _segmentoRepositorioMock.Setup(r => r.Remover(7)).Returns(Task.CompletedTask);

            await _segmentoServico.Remover(7);

            _segmentoRepositorioMock.Verify(r => r.Remover(7), Times.Once);
        }

        [Fact]
        public async Task Remover_DeveLancarExcecao_QuandoSegmentoNaoExiste()
        {
            _segmentoRepositorioMock.Setup(r => r.ObterPorId(8)).ReturnsAsync((Segmento)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _segmentoServico.Remover(8));
            Assert.Equal("Segmento com Id 8 não encontrado.", ex.Message);
        }
    }
}
