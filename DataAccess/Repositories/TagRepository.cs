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
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Tags.Where(t => ids.Contains(t.TagId)).ToListAsync();
        }
    }
}
