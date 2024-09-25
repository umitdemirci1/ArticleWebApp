using Business.IServices;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, IEmailSender emailSender, IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return null;
            }
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var rememberMe = request.RememberMe;

                var token = _tokenService.GenerateJwtToken(user, userRoles, rememberMe);

                return token;
            }
            return null;
        }

        public async Task<string> RefreshTokenAsync(string refreshToken)
        {
            // Yenileme token'ını doğrulayın
            var user = await _userManager.FindByIdAsync(refreshToken);
            if (user == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var newToken = _tokenService.GenerateJwtToken(user, roles, false);

            return newToken;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "This user is already exists" });
            }

            var user = new AppUser
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(request.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(request.Role));
                }
                await _userManager.AddToRoleAsync(user, request.Role);
            }
            return result;
        }

        public async Task SendVerificationCodeAsync(string email)
        {
            var code = GenerateVerificationCode();
            await _emailSender.SendEmailAsync(email, "Verification Code", $"Your verification code is {code}");
            // Doğrulama kodunu saklayın (örneğin, veritabanında veya cache'de)
        }

        public bool VerifyCode(string email, string code)
        {
            // Doğrulama kodunu kontrol edin (örneğin, veritabanından veya cache'den alın)
            return true; // Doğrulama başarılıysa true döndürün
        }

        private string GenerateVerificationCode()
        {
            // Doğrulama kodu oluşturma işlemi
            return "123456";
        }
    }
}
