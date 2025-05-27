using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;

namespace SimuladorCredito.Api.Data.Seed
{
    public static class SegmentoSeed
    {
        public static List<Segmento> ObterSegmentos()
        {
            var data = new DateTime(2024, 01, 01);
            return new List<Segmento>()
            {
                new Segmento
                {
                    Id = 1,
                    Nome = "Start",
                    Descricao = "Segmento inicial para PF com renda até R$3.000",
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    RendaMinima = 0.00m,
                    RendaMaxima = 3000.00m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new Segmento
                {
                    Id = 2,
                    Nome = "Intermediário",
                    Descricao = "PF com renda entre R$3.001 e R$10.000",
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    RendaMinima = 3000.01m,
                    RendaMaxima = 10000.00m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new Segmento
                {
                    Id = 3,
                    Nome = "Premium",
                    Descricao = "PF com renda acima de R$10.000",
                    TipoPessoa = TipoPessoa.PessoaFisica,
                    RendaMinima = 10000.01m,
                    RendaMaxima = null,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },

                // Pessoa Jurídica
                new Segmento
                {
                    Id = 4,
                    Nome = "Empreendedor",
                    Descricao = "PJ com renda até R$20.000",
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    RendaMinima = 0.00m,
                    RendaMaxima = 20000.00m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new Segmento
                {
                    Id = 5,
                    Nome = "Empresarial",
                    Descricao = "PJ com renda entre R$20.001 e R$100.000",
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    RendaMinima = 20000.01m,
                    RendaMaxima = 100000.00m,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                },
                new Segmento
                {
                    Id = 6,
                    Nome = "Corporativo",
                    Descricao = "PJ com renda acima de R$100.000",
                    TipoPessoa = TipoPessoa.PessoaJuridica,
                    RendaMinima = 100000.01m,
                    RendaMaxima = null,
                    DataCadastro = data,
                    DataAlteracao = data,
                    Ativo = true
                }
            };
        }
    }
}
