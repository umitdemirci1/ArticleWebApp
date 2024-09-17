using Business.IServices;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HomeCardService : IHomeCardService
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;
        private readonly IViewService _viewService;

        public HomeCardService(IArticleService articleService, IUserService userService, ILikeService likeService, IViewService viewService)
        {
            _articleService = articleService;
            _userService = userService;
            _likeService = likeService;
            _viewService = viewService;
        }

        public async Task<IEnumerable<HomeCardDto>> GetHomeCardDataAsync()
        {
            var articles = await _articleService.GetHomeArticlesAsync();

            var homeCardDtos = new List<HomeCardDto>();

            foreach (var article in articles)
            {
                var user = await _userService.GetHomeCardUserByIdAsync(article.UserId);
                var likeCount = await _likeService.CountArticleLikeAsync(article.Id);
                var viewCount = await _viewService.CountArticleViewsAsync(article.Id);

                var homeCardDto = new HomeCardDto
                {
                    Article = article,
                    AppUser = user,
                    LikeCount = likeCount,
                    ViewCount = viewCount
                };

                homeCardDtos.Add(homeCardDto);
            }

            return homeCardDtos;
        }
    }
}
