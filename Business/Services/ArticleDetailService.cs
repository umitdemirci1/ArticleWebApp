using Business.IServices;
using Core.DTOs;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ArticleDetailService : IArticleDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ArticleDetailDto> GetArticleDetails(int articleId, Guid clientId)
        {
            var article = await _unitOfWork.Articles.Include(a => a.ArticleImages)
                                                    .Include(a => a.ArticleComments)
                                                    .FirstOrDefaultAsync(a => a.Id == articleId);

            if (article == null)
            {
                return null;
            }

            var articleDto = new ArticleDetailDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                HasGallery = article.ArticleImages.Any(),
                articleImages = article.ArticleImages.Select(ai => new ArticleDetailImageDto
                {
                    Id = ai.Id,
                    Data = ai.Data,
                    AltText = ai.AltText,
                    Caption = ai.Caption,
                    Position = ai.Position,
                    UploadedAt = ai.UploadedAt
                }).ToList(),
                Comments = article.ArticleComments,
                ViewCount = await GetArticleViewCount(articleId),
                LikeCount = await GetArticleLikeCount(articleId),
                IsLiked = await ArticleLikeStatus(articleId, clientId)
            };

            return articleDto;
        }

        public async Task<int> GetArticleViewCount(int articleId)
        {
            return await _unitOfWork.ArticleViews.CountAsync(av => av.ArticleId == articleId);
        }

        public async Task<int> GetArticleLikeCount(int articleId)
        {
            return await _unitOfWork.ArticleLikes.CountAsync(al => al.ArticleId == articleId);
        }

        public async Task<bool> ArticleLikeStatus(int articleId, Guid clientId)
        {
            var result = await _unitOfWork.ArticleLikes.CountAsync(al => al.ArticleId == articleId && al.AppUserId == clientId);

            if (result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}