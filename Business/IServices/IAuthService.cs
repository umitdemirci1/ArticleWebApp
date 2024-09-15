using Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
        Task<IdentityResult> RegisterAsync(RegisterRequest request);
        Task SendVerificationCodeAsync(string email);
        bool VerifyCode(string email, string code);
    }
}
