using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Repositorios.Interfaces;

namespace SimuladorCredito.Api.Repositorios
{
    public class TaxaCreditoRepositorio : RepositorioBase<TaxaCredito>, ITaxaCreditoRepositorio
    {
        public TaxaCreditoRepositorio(DbContextClass context) : base(context)
        {
        }

        public async Task<List<TaxaCredito>> ObterTodosInclude()
        {
            return await _context.TaxasCredito.Include(x => x.Segmento).Include(x => x.Produto).ToListAsync();
        }
        public async Task<TaxaCredito?> ObterTaxaSimulacao(SimularCreditoEntrada simularCreditoEntrada)
        {
            return await _context.TaxasCredito
                .Include(x => x.Segmento)
                .Where(x => 
                    x.Ativo && 
                    x.TipoPessoa == simularCreditoEntrada.TipoPessoa && 
                    x.ProdutoId == simularCreditoEntrada.ProdutoId && 
                    x.Modalidade == simularCreditoEntrada.Modalidade && 
                    x.Segmento.Ativo && 
                    x.Segmento.TipoPessoa == simularCreditoEntrada.TipoPessoa && 
                    x.Segmento.RendaMinima <= simularCreditoEntrada.Renda && 
                    (
                        x.Segmento.RendaMaxima.HasValue && 
                        x.Segmento.RendaMaxima >= simularCreditoEntrada.Renda || 
                        !x.Segmento.RendaMaxima.HasValue
                    ))
                .FirstOrDefaultAsync();
        }


    }
}
