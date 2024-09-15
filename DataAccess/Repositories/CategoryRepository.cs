using DataAccess.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Categories.Where(x => ids.Contains(x.CategoryId)).ToListAsync();
        }
    }
}
