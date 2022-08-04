using System.Linq.Expressions;

namespace Sample.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Remove(T entity);

        void Update(T entity);

        //void AddRange(IEnumerable<T> entities);
        //IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        //void Add(T entity);
        //void RemoveRange(IEnumerable<T> entities);
    }
}
