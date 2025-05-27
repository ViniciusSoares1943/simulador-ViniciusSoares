using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Data.Seed
{
    public static class ProdutoSeed
    {
        public static List<Produto> ObterProdutos()
        {
            var data = new DateTime(2024, 01, 01);
            return new List<Produto>()
            {
                new Produto()
                {
                    Id = 1,
                    Nome = "Financiamento",
                    Descricao = "Financiamento de pessoas físicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                },
                new Produto()
                {
                    Id = 2,
                    Nome = "Sicoob Engecred Consignado",
                    Descricao = "Sicoob Engecred Consignado",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                },
                new Produto()
                {
                    Id = 3,
                    Nome = "Empréstimo Pessoal",
                    Descricao = "Empréstimo Pessoal de pessoas físicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                },
                new Produto()
                {
                    Id = 4,
                    Nome = "Imóveis",
                    Descricao = "Imóveis de pessoas físicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                },
                new Produto()
                {
                    Id = 5,
                    Nome = "Financiamento",
                    Descricao = "Financiamento de pessoas jurídicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                },
                new Produto()
                {
                    Id = 6,
                    Nome = "Crédito Rural",
                    Descricao = "Crédito Rural",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                },
                new Produto()
                {
                    Id = 7,
                    Nome = "Empréstimo Pessoal",
                    Descricao = "Empréstimo Pessoal de pessoas jurídicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                },
                new Produto()
                {
                    Id = 8,
                    Nome = "Imóveis",
                    Descricao = "Imóveis de pessoas jurídicas",
                    Ativo = true,
                    DataAlteracao = data,
                    DataCadastro = data,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                }
            };
        }
    }
}
