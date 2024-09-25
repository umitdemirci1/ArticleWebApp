using BlogProject.MVC.Helpers;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClientHelper _apiClientHelper;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ApiClientHelper apiClientHelper, ILogger<AccountController> logger)
        {
            _apiClientHelper = apiClientHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserToken") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");  
                var response = await _apiClientHelper.PostAsync<TokenResponse>("auth/login", content);

                if (response != null)
                {
                    var token = response.Token;
                    HttpContext.Session.SetString("UserToken", token);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login failed.");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _apiClientHelper.PostAsync<HttpResponseMessage>("auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiErrors = JsonConvert.DeserializeObject<ApiErrorResponse>(responseContent);

            if (apiErrors != null && apiErrors.Errors != null)
            {
                foreach (var error in apiErrors.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Registration failed. Please check your details and try again.");
            }

            return View(request);
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }

    public class ApiErrorResponse
    {
        public string[] Errors { get; set; }
    }
}
