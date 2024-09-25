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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiClientHelper _apiClientHelper;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, ApiClientHelper apiClientHelper, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _apiClientHelper = apiClientHelper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var cardDtos = await _apiClientHelper.GetAsync<IEnumerable<HomeCardDto>>("Home/HomeCard");

            if (cardDtos == null)
            {
                return View(new List<HomeCardDto>());
            }
            return View(cardDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var articleDetailDto = await _apiClientHelper.GetAsync<ArticleDetailDto>($"Home/HomeCard/Details/{id}");
            if (articleDetailDto == null)
            {
                _logger.LogError("The API request failed or no data was found.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(articleDetailDto);
        }


        public async Task<IActionResult> Privacy()
        {
            var result = await _apiClientHelper.GetAsync<string>($"Home/HomeCard/Test");
            if (result == null)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View();
        }


        public async Task<IActionResult> AdminOnly()
        {
            var apiUrl = "https://localhost:7242/api/Home/AdminOnly";
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return View("AdminOnly", data);
            }
            else
            {
                return View("Error", "Unauthorized access or other error occurred.");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
