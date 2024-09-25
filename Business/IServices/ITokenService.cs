using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ITokenService
    {
        string GenerateJwtToken(AppUser user, IList<string> roles, bool rememberMe);
    }
}
