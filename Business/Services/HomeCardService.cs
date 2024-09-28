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
        private readonly IHomeCardDataService _homeCardDataService;
        public HomeCardService(IHomeCardDataService homeCardDataService)
        {
            _homeCardDataService = homeCardDataService;
        }

        public async Task<IEnumerable<HomeCardDto>> GetHomeCardDataAsync()
        {
            var articles = await _homeCardDataService.GetHomeArticlesAsync();

            var homeCardDtos = new List<HomeCardDto>();

            foreach (var article in articles)
            {
                var user = await _homeCardDataService.GetHomeCardUserByIdAsync(article.UserId);
                var likeCount = await _homeCardDataService.CountArticleLikeAsync(article.Id);
                var viewCount = await _homeCardDataService.CountArticleViewsAsync(article.Id);

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
