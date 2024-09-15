using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id); //zaten soft delete olacak, task türü olmalı.
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
