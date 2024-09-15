using Core.Models;
using DataAccess.IRepositories;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;

        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            ArticleImages = new ArticleImageRepository(_context);
            ArticleViews = new ArticleViewRepository(_context);
            ArticleLikes = new ArticleLikeRepository(_context);
            ArticleComments = new ArticleCommentRepository(_context);
            Categories = new CategoryRepository(_context);
            ArticleCategories = new ArticleCategoryRepository(_context);
            Tags = new TagRepository(_context);
            ArticleTags = new ArticleTagRepository(_context);
            Users = new UserRepository(_context);
        }
        
        public IArticleRepository Articles { get; private set; }
        public IArticleImageRepository ArticleImages { get; private set; }
        public IArticleViewRepository ArticleViews { get; private set; }
        public IArticleLikeRepository ArticleLikes { get; private set; }
        public IArticleCommentRepository ArticleComments { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IArticleCategoryRepository ArticleCategories { get; private set; }
        public ITagRepository Tags { get; private set; }
        public IArticleTagRepository ArticleTags { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
