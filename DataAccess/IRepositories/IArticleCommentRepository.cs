using Core.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IArticleCommentRepository : IRepository<ArticleComment>
    {
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<ArticleComment, bool>> expression);
    }
}
