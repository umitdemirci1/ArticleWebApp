using Business.IServices;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender, IConfiguration configuration, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var rememberMe = request.RememberMe;
            var token = GenerateJwtToken(user, roles, rememberMe);

            return token;
        }

        private string GenerateJwtToken(AppUser user, IList<string> roles, bool rememberMe)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: rememberMe ? DateTime.Now.AddDays(3) : DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
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
                    await _roleManager.CreateAsync(new IdentityRole<int>(request.Role));
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
