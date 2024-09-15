using BlogProject.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using BlogProject.MVC.Helpers;
using Core.DTOs;


namespace BlogProject.MVC.Controllers
{
    [ServiceFilter(typeof(TokenCheckFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ApiClientHelper _apiClientHelper;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, ApiClientHelper apiClientHelper)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiClientHelper = apiClientHelper;
        }
 
        public async Task<IActionResult> Index()
        {      
            var articles = await _apiClientHelper.GetAsync<IEnumerable<ArticleWithAuthorDTO>>("Article/GetAllArticlesWithAuthor/WithAuthor");

            if(articles == null)
            {
                return View(new List<ArticleWithAuthorDTO>());
            }
            return View(articles);
        }
        public async Task<IActionResult> Details(int id)
        {
            var article = await _apiClientHelper.GetAsync<ArticleWithAuthorDTO>($"/articles/{id}");
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
