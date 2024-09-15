using Business.Helpers;
using Business.IServices;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public AccountController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kaydetme işlemleri burada yapılır
                // Örneğin, kullanıcıyı veritabanına kaydedin


                // Doğrulama kodunu oluşturun
                var verificationCode = VerificationCodeHelper.GenerateVerificationCode();

                // Doğrulama kodunu e-posta ile gönderin
                await _emailSender.SendEmailAsync(model.Email, "Doğrulama Kodu", $"Doğrulama kodunuz: {verificationCode}");

                // Doğrulama kodunu veritabanına veya geçici bir depolama alanına kaydedin

                return Ok(new { message = "Kayıt başarılı, doğrulama kodu gönderildi." });
            }

            return BadRequest(ModelState);
        }

        [HttpPost("verify")]
        public IActionResult Verify([FromBody] VerifyRequest model)
        {
            if (ModelState.IsValid)
            {
                // Doğrulama kodunu kontrol edin
                // if (verificationCodeIsValid)
                // {
                //     Kullanıcıyı doğrulanmış olarak işaretleyin
                //     return Ok(new { message = "Doğrulama başarılı." });
                // }

                return BadRequest(new { message = "Geçersiz doğrulama kodu." });
            }

            return BadRequest(ModelState);
        }
    }
}
