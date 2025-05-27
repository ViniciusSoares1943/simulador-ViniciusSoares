using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Repositorios.Interfaces;

namespace SimuladorCredito.Api.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly DbContextClass _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBase(DbContextClass context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> ObterPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Adicionar(T entidade)
        {
            await _dbSet.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var entidade = await ObterPorId(id);
            if (entidade != null)
            {
                _dbSet.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
