using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<ArticleWithAuthorDTO>> GetPublishedArticlesWithAuthor();
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<Article, bool>> expression);
    }
}
