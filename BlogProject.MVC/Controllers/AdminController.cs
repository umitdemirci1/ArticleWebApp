using BlogProject.MVC.Helpers;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApiClientHelper _apiClientHelper;
        public AdminController(ApiClientHelper apiClientHelper)
        {
            _apiClientHelper = apiClientHelper;
        }

        public async Task<IActionResult> Index()
        {
            var stats = await _apiClientHelper.GetAsync<AdminStatsDTO>("Admin/dashboard");
            //null check yapılabilir
            return View(stats);
        }
    }
}
