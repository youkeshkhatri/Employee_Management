using Microsoft.EntityFrameworkCore;
using Sample.Models;
using System.Linq.Expressions;

namespace Sample.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TaskContext _context;

        public GenericRepository(TaskContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
        }
    }
}
