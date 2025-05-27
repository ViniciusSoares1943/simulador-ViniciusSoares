using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Data.Seed
{
    public static class TaxaCreditoSeed
    {
        public static List<TaxaCredito> ObterTaxasCredito()
        {
            var data = new DateTime(2024, 01, 01);
            return new List<TaxaCredito>()
            {
                // Pessoa Física
                // Pre-fixado
                // Produto 1 - Financiamento
                new TaxaCredito
                {
                    Id = 1,
                    ProdutoId = 1,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.10m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true 
                },
                new TaxaCredito
                {
                    Id = 2,
                    ProdutoId = 1,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.09m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 3,
                    ProdutoId = 1,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.08m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 3 - Empréstimo Pessoal
                new TaxaCredito
                {
                    Id = 4,
                    ProdutoId = 3,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.09m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 5,
                    ProdutoId = 3,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.08m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 6,
                    ProdutoId = 3,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.07m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 4 - Imóveis
                new TaxaCredito
                {
                    Id = 7,
                    ProdutoId = 4,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.20m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 8,
                    ProdutoId = 4,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.25m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 9,
                    ProdutoId = 4,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.30m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },

                // Pós-fixado
                // Produto 1 - Financiamento
                new TaxaCredito
                {
                    Id = 10,
                    ProdutoId = 1,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.06m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 11,
                    ProdutoId = 1,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 12,
                    ProdutoId = 1,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 2 - Sicoob Engecred Consignado
                new TaxaCredito
                {
                    Id = 13,
                    ProdutoId = 2,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 14,
                    ProdutoId = 2,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 15,
                    ProdutoId = 2,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.03m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 3 - Empréstimo Pessoal
                new TaxaCredito
                {
                    Id = 16,
                    ProdutoId = 3,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 17,
                    ProdutoId = 3,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 18,
                    ProdutoId = 3,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.03m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 4 - Imóveis
                new TaxaCredito
                {
                    Id = 19,
                    ProdutoId = 4,
                    SegmentoId = 1,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.40m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 20,
                    ProdutoId = 4,
                    SegmentoId = 2,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.45m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 21,
                    ProdutoId = 4,
                    SegmentoId = 3,
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.50m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Pessoa Jurídica
                // Pré Fixado
                // Produto 5 - Financiamento
                new TaxaCredito
                {
                    Id = 22,
                    ProdutoId = 5,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.10m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 23,
                    ProdutoId = 5,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.09m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 24,
                    ProdutoId = 5,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.08m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 6 - Crédito Rural
                new TaxaCredito
                {
                    Id = 25,
                    ProdutoId = 6,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 26,
                    ProdutoId = 6,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 27,
                    ProdutoId = 6,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.03m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 7 - Empréstimo Pessoal
                new TaxaCredito
                {
                    Id = 28,
                    ProdutoId = 7,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.09m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 29,
                    ProdutoId = 7,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.08m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 30,
                    ProdutoId = 7,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.07m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 8 - Imóveis
                new TaxaCredito
                {
                    Id = 31,
                    ProdutoId = 8,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.20m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 32,
                    ProdutoId = 8,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.25m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 33,
                    ProdutoId = 8,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PreFixado,
                    Taxa = 0.30m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Pós Fixado
                // Produto 5 - Financiamento
                new TaxaCredito
                {
                    Id = 34,
                    ProdutoId = 5,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.06m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 35,
                    ProdutoId = 5,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 36,
                    ProdutoId = 5,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 6 - Crédito Rural
                new TaxaCredito
                {
                    Id = 37,
                    ProdutoId = 6,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.01m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 38,
                    ProdutoId = 6,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.005m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 39,
                    ProdutoId = 6,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.005m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 7 - Empréstimo Pessoal
                new TaxaCredito
                {
                    Id = 40,
                    ProdutoId = 7,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.05m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 41,
                    ProdutoId = 7,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.04m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 42,
                    ProdutoId = 7,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.03m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                // Produto 8 - Imóveis
                new TaxaCredito
                {
                    Id = 43,
                    ProdutoId = 8,
                    SegmentoId = 4,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.40m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 44,
                    ProdutoId = 8,
                    SegmentoId = 5,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.45m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new TaxaCredito
                {
                    Id = 45,
                    ProdutoId = 8,
                    SegmentoId = 6,
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    Modalidade = Modalidade.PosFixado,
                    Taxa = 0.50m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                }
             };
        }
    }
}
