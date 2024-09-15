using DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        IArticleImageRepository ArticleImages { get; }
        IArticleViewRepository ArticleViews { get; }
        IArticleLikeRepository ArticleLikes { get; }
        IArticleCommentRepository ArticleComments { get; }
        ICategoryRepository Categories { get; }
        IArticleCategoryRepository ArticleCategories { get; }
        ITagRepository Tags { get; }
        IArticleTagRepository ArticleTags { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
