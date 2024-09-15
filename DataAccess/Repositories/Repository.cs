using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BlogDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(BlogDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity not found");
            }

            // Soft delete işlemi
            var softDeleteProperty = entity.GetType().GetProperty("IsDeleted");
            if (softDeleteProperty != null)
            {
                softDeleteProperty.SetValue(entity, true);
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        // Belirli bir koşula göre veritabanında arama yap
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Include işlemi için metot
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
