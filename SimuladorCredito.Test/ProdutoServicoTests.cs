using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos;
using Xunit;

namespace SimuladorCredito.Test
{
    public class ProdutoServicoTests
    {
        private readonly Mock<IProdutoRepositorio> _produtoRepositorioMock;
        private readonly ProdutoServico _produtoServico;

        public ProdutoServicoTests()
        {
            _produtoRepositorioMock = new Mock<IProdutoRepositorio>();
            _produtoServico = new ProdutoServico(_produtoRepositorioMock.Object);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarProduto_QuandoEncontrado()
        {
            var produto = new Produto 
            { 
                Id = 1,
                Nome = "Teste",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                DataCadastro = DateTime.Now,
                Ativo = true,
                DataAlteracao = DateTime.Now
            };
            _produtoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync(produto);

            var resultado = await _produtoServico.ObterPorId(1);

            Assert.Equal(produto, resultado);
        }

        [Fact]
        public async Task ObterPorId_DeveLancarExcecao_QuandoNaoEncontrado()
        {
            _produtoRepositorioMock.Setup(r => r.ObterPorId(1)).ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.ObterPorId(1));
            Assert.Equal("Produto com Id 1 não encontrado.", ex.Message);
        }

        [Fact]
        public async Task ObterTodos_DeveRetornarListaDeProdutos()
        {
            var lista = new List<Produto>
            {
                new Produto 
                { 
                    Id = 1,
                    Nome = "A",
                    Descricao = "D",
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    DataCadastro = DateTime.Now,
                    Ativo = true,
                    DataAlteracao = DateTime.Now
                }
            };
            _produtoRepositorioMock.Setup(r => r.ObterTodos()).ReturnsAsync(lista);

            var resultado = await _produtoServico.ObterTodos();

            Assert.Single(resultado);
            Assert.Equal(lista[0], resultado[0]);
        }

        [Fact]
        public async Task ObterPorTipoPessoa_DeveRetornarListaDeProdutoSaida()
        {
            var produtos = new List<Produto>
            {
                new Produto 
                { 
                    Id = 2,
                    Nome = "B",
                    Descricao = "DescB",
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    DataCadastro = DateTime.Now,
                    Ativo = true,
                    DataAlteracao = DateTime.Now
                }
            };
            _produtoRepositorioMock.Setup(r => r.ObterPorTipoPessoa(TipoPessoa.PessoaJuridica)).ReturnsAsync(produtos);

            var resultado = await _produtoServico.ObterPorTipoPessoa(TipoPessoa.PessoaJuridica);

            Assert.Single(resultado);
            Assert.Equal(produtos[0].TipoPessoa, resultado[0].TipoPessoa);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarProduto_QuandoValido()
        {
            var produto = new Produto 
            {
                Nome = "Novo",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica
            };
            _produtoRepositorioMock.Setup(r => r.Adicionar(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            await _produtoServico.Adicionar(produto);

            _produtoRepositorioMock.Verify(r => r.Adicionar(It.Is<Produto>(p =>
                p.Nome == "Novo" &&
                p.Descricao == "Desc" &&
                p.TipoPessoa == TipoPessoa.PessoaFisica &&
                p.Ativo == true
            )), Times.Once);
        }

        [Fact]
        public async Task Adicionar_DeveLancarExcecao_QuandoProdutoNulo()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.Adicionar(null));
            Assert.Equal("Produto não pode ser nulo.", ex.Message);
        }

        [Fact]
        public async Task Adicionar_DeveLancarExcecao_QuandoNomeVazio()
        {
            var produto = new Produto 
            {
                Nome = "",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica
            };
            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.Adicionar(produto));
            Assert.Equal("O nome do produto é obrigatório.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveAtualizarProduto_QuandoValido()
        {
            var produto = new Produto
            {
                Id = 5,
                Nome = "Atualizado",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica,
                Ativo = true
            };
            var existente = new Produto
            {
                Id = 5,
                Nome = "Antigo",
                Descricao = "Antiga",
                TipoPessoa = TipoPessoa.PessoaJuridica,
                Ativo = false,
                DataAlteracao = DateTime.MinValue
            };
            _produtoRepositorioMock.Setup(r => r.ObterPorId(5)).ReturnsAsync(existente);
            _produtoRepositorioMock.Setup(r => r.Atualizar(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            await _produtoServico.Atualizar(produto);

            _produtoRepositorioMock.Verify(r => r.Atualizar(It.Is<Produto>(p =>
                p.Id == 5 &&
                p.Nome == "Atualizado" &&
                p.Descricao == "Desc" &&
                p.TipoPessoa == TipoPessoa.PessoaFisica &&
                p.Ativo == true &&
                p.DataAlteracao > DateTime.MinValue
            )), Times.Once);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoProdutoNulo()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.Atualizar(null));
            Assert.Equal("Produto não pode ser nulo.", ex.Message);
        }

        [Fact]
        public async Task Atualizar_DeveLancarExcecao_QuandoProdutoNaoExiste()
        {
            var produto = new Produto 
            { 
                Id = 10, 
                Nome = "Produto X", 
                Descricao = "X Produto", 
                TipoPessoa = TipoPessoa.PessoaFisica 
            };
            _produtoRepositorioMock.Setup(r => r.ObterPorId(10)).ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.Atualizar(produto));
            Assert.Equal("Produto com Id 10 não encontrado.", ex.Message);
        }

        [Fact]
        public async Task Remover_DeveRemoverProduto_QuandoExiste()
        {
            var produto = new Produto
            {
                Id = 7,
                Nome = "Remover",
                Descricao = "Desc",
                TipoPessoa = TipoPessoa.PessoaFisica
            };
            _produtoRepositorioMock.Setup(r => r.ObterPorId(7)).ReturnsAsync(produto);
            _produtoRepositorioMock.Setup(r => r.Remover(7)).Returns(Task.CompletedTask);

            await _produtoServico.Remover(7);

            _produtoRepositorioMock.Verify(r => r.Remover(7), Times.Once);
        }

        [Fact]
        public async Task Remover_DeveLancarExcecao_QuandoProdutoNaoExiste()
        {
            _produtoRepositorioMock.Setup(r => r.ObterPorId(8)).ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _produtoServico.Remover(8));
            Assert.Equal("Produto com Id 8 não encontrado.", ex.Message);
        }
    }
}
