using DataAccess.IRepository;
using Core.Models;
using Core.DTOs;
using Business.IServices;

namespace Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _unitOfWork.Articles.FindAsync(article => article.IsPublished == true);
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _unitOfWork.Articles.GetByIdAsync(id);
        }

        public async Task<int> AddArticleAsync(ArticleDto articleDto)
        {
            var article = new Article
            {
                Title = articleDto.Title,
                Content = articleDto.Content,
                AppUserId = articleDto.AppUserId,
                CoverImageUrl = articleDto.CoverImageUrl,
                HasGallery = articleDto.HasGallery,
            };

            // Kategorileri ekle
            var categories = await _unitOfWork.Categories.GetByIdsAsync(articleDto.CategoryIds);
            foreach (var category in categories)
            {
                article.ArticleCategories.Add(new ArticleCategory { Article = article, Category = category });
            }

            // Etiketleri ekle
            var tags = await _unitOfWork.Tags.GetByIdsAsync(articleDto.TagIds);
            foreach (var tag in tags)
            {
                article.ArticleTags.Add(new ArticleTag { Article = article, Tag = tag });
            }

            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveChangesAsync();

            return article.Id;
        }

        public async Task UpdateArticleAsync(Article article)
        {
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _unitOfWork.Articles.GetByIdAsync(id);
            if (article != null)
            {
                await _unitOfWork.Articles.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Article>> GetArticlesByAuthorAsync(int authorId)
        {
            return await _unitOfWork.Articles.FindAsync(a => a.AppUserId == authorId);
        }
    }
}
