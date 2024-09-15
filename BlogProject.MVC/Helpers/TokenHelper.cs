using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogProject.MVC.Helpers
{
    public static class TokenHelper
    {
        public static IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims;
        }
    }
}
