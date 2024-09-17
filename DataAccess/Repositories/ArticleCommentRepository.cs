using Core.Models;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleCommentRepository : Repository<ArticleComment>, IArticleCommentRepository
    {
        public ArticleCommentRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<int> CountAsync()
        {
            return await _context.ArticleComments.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<ArticleComment, bool>> expression)
        {
            return await _context.ArticleComments.CountAsync(expression);
        }
    }
}
