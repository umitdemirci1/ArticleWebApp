using Business.IServices;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HomeCardDataService : IHomeCardDataService
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;
        private readonly IViewService _viewService;

        public HomeCardDataService(IArticleService articleService, IUserService userService, ILikeService likeService, IViewService viewService)
        {
            _articleService = articleService;
            _userService = userService;
            _likeService = likeService;
            _viewService = viewService;
        }

        public Task<IEnumerable<HomeCardArticleDto>> GetHomeArticlesAsync() => _articleService.GetHomeArticlesAsync();
        public Task<HomeCardAppUserDto> GetHomeCardUserByIdAsync(Guid userId) => _userService.GetHomeCardUserByIdAsync(userId);
        public Task<int> CountArticleLikeAsync(int articleId) => _likeService.CountArticleLikeAsync(articleId);
        public Task<int> CountArticleViewsAsync(int articleId) => _viewService.CountArticleViewsAsync(articleId);
    }
}
