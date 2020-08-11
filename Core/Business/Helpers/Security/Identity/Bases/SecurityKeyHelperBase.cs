using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Business.Helpers.Security.Identity.Bases
{
    public abstract class SecurityKeyHelperBase
    {
        public virtual SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
