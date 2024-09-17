using DataAccess.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<int> CountAsync()
        {
            return await _context.Articles.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<Article, bool>> expression)
        {
            return await _context.Articles.CountAsync(expression);
        }

        public async Task<IEnumerable<ArticleWithAuthorDTO>> GetPublishedArticlesWithAuthor()
        {
            return await _context.Articles
                .Where(a => a.IsPublished)
                .Include(a => a.AppUser)
                .Select(a => new ArticleWithAuthorDTO
                {
                    ArticleId = a.Id,
                    Title = a.Title,
                    AuthorId = a.AppUser.Id,
                    AuthorFullName = a.AppUser.FullName
                })
                .ToListAsync();
        }
    }
}
