using Business.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeCardService _homeCardService;

        public HomeController(IHomeCardService homeCardService)
        {
            _homeCardService = homeCardService;
        }

        [HttpGet("HomeCard")]
        public async Task<IActionResult> GetHomeCardData()
        {
            var datas = await _homeCardService.GetHomeCardDataAsync();
            return Ok(datas);
        }
    }
}
