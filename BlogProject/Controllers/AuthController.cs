using Business.IServices;
using Business.Services;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost("send-verification-code")]
        public async Task<IActionResult> SendVerificationCode([FromBody] string email)
        {
            await _authService.SendVerificationCodeAsync(email);
            return Ok();
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerifyRequest request)
        {
            var isValid = _authService.VerifyCode(request.Email, request.Code);
            if (!isValid)
            {
                return BadRequest("Invalid verification code.");
            }
            return Ok();
        }
    }

}
