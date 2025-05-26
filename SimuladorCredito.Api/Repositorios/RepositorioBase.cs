using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimuladorCredito.Api.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T?> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(int id);
    }

    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly DbContextClass _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBase(DbContextClass context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> ObterPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task AdicionarAsync(T entidade)
        {
            await _dbSet.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            _dbSet.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoverAsync(int id)
        {
            var entidade = await ObterPorIdAsync(id);
            if (entidade != null)
            {
                _dbSet.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
