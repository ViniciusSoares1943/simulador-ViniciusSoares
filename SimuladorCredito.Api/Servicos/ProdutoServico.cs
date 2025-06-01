using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<Produto> ObterPorId(int id)
        {
            var produto = await _produtoRepositorio.ObterPorId(id);
            if (produto == null)
                throw new Exception($"Produto com Id {id} não encontrado.");
            return produto;
        }

        public async Task<List<Produto>> ObterTodos()
        {
            return await _produtoRepositorio.ObterTodos();
        }

        public async Task<List<ProdutoSaida>> ObterPorTipoPessoa(TipoPessoa tipoPessoa)
        {
            var produtos = await _produtoRepositorio.ObterPorTipoPessoa(tipoPessoa);

            return produtos.Select(x => new ProdutoSaida
            {
                Nome = x.Nome,
                Descricao = x.Descricao,
                TipoPessoa = x.TipoPessoa,
                DataCadastro = x.DataCadastro,
                ProdutoId = x.Id
            }).ToList();
        }

        public async Task Adicionar(Produto produto)
        {
            if (produto == null)
                throw new Exception("Produto não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("O nome do produto é obrigatório.");

            produto.DataCadastro = DateTime.Now;
            produto.DataAlteracao = DateTime.Now;
            produto.Ativo = true;

            await _produtoRepositorio.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (produto == null)
                throw new Exception("Produto não pode ser nulo.");

            var existente = await _produtoRepositorio.ObterPorId(produto.Id);
            if (existente == null)
                throw new Exception($"Produto com Id {produto.Id} não encontrado.");

            existente.DataAlteracao = DateTime.Now;
            existente.Nome = produto.Nome;
            existente.Descricao = produto.Descricao;
            existente.TipoPessoa = produto.TipoPessoa;
            existente.Ativo = produto.Ativo;

            await _produtoRepositorio.Atualizar(existente);
        }

        public async Task Remover(int id)
        {
            var existente = await _produtoRepositorio.ObterPorId(id);
            if (existente == null)
                throw new Exception($"Produto com Id {id} não encontrado.");

            await _produtoRepositorio.Remover(id);
        }
    }
}
