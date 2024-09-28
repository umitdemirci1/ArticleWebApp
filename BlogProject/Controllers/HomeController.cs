using Business.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogProject.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeCardService _homeCardService;
        private readonly IArticleDetailService _articleDetailService;

        public HomeController(IHomeCardService homeCardService, IArticleDetailService articleDetailService)
        {
            _homeCardService = homeCardService;
            _articleDetailService = articleDetailService;
        }

        [HttpGet("HomeCard")]
        public async Task<IActionResult> GetHomeCardData()
        {
            var headers = Request.Headers;
            var datas = await _homeCardService.GetHomeCardDataAsync();
            return Ok(datas);
        }

        [Authorize(Roles = "Author")]
        [HttpGet]
        [Route("HomeCard/Details/{id}")]
        public async Task<IActionResult> GetArticleDetailsById(int id)
        {
            var clientIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (clientIdClaim == null)
            {
                return Unauthorized("Kullanıcı kimliği bulunamadı.");
            }

            if (!Guid.TryParse(clientIdClaim.Value, out Guid clientId))
            {
                return BadRequest("Geçersiz kullanıcı kimliği.");
            }

            var data = await _articleDetailService.GetArticleDetails(id, clientId);
            if (data == null)
            {
                return NotFound("Makale bulunamadı.");
            }

            return Ok(data);
        }

        // Yalnızca Admin rolünde olanların erişebileceği endpoint
        [Authorize(Roles = "Admin")]
        [HttpGet("AdminOnly")]
        public IActionResult GetAdminOnlyData()
        {
            return Ok("Bu veriye yalnızca Admin rolündeki kullanıcılar erişebilir.");
        }
    }
}
