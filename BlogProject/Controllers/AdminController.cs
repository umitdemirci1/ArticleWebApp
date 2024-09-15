using Business.IServices;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardData()
        {
            var stats = await _adminService.GetAdminDashboardDataAsync();
            return Ok(stats);
        }
    }
}
