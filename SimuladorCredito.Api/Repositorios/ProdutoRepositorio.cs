using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Repositorios.Interfaces;

namespace SimuladorCredito.Api.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(DbContextClass context) : base(context)
        {
        }

        public async Task<List<Produto>> ObterPorTipoPessoa(TipoPessoa tipoPessoa)
        {
            var produtos = await _context.Produtos
                .Where(x => 
                    x.TipoPessoa == tipoPessoa
                    && x.Ativo)
                .ToListAsync();
            return produtos;
        }
    }
}
