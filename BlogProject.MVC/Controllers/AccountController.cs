using BlogProject.MVC.Helpers;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClientHelper _apiClientHelper;

        public AccountController(ApiClientHelper apiClientHelper)
        {
            _apiClientHelper = apiClientHelper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            if (Request.Cookies.ContainsKey("UserToken"))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = await _apiClientHelper.PostAsync<TokenResponse>("Auth/login", content);

                if (response != null)
                {
                    Response.Cookies.Append("UserToken", response.Token);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Login failed: {ex.Message}");
            }

            return View();
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
