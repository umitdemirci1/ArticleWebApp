using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IHomeCardDataService
    {
        Task<IEnumerable<HomeCardArticleDto>> GetHomeArticlesAsync();
        Task<HomeCardAppUserDto> GetHomeCardUserByIdAsync(Guid userId);
        Task<int> CountArticleLikeAsync(int articleId);
        Task<int> CountArticleViewsAsync(int articleId);
    }
}
