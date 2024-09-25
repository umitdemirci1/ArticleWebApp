using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IArticleDetailService
    {
        Task<ArticleDetailDto> GetArticleDetails(int articleId, Guid clientId);
        Task<bool> ArticleLikeStatus(int articleId, Guid clientId);
        Task<int> GetArticleLikeCount(int articleId);
        Task<int> GetArticleViewCount(int articleId);
    }
}
