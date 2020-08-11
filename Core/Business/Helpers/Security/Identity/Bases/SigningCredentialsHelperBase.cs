using Microsoft.IdentityModel.Tokens;

namespace Core.Business.Helpers.Security.Identity.Bases
{
    public abstract class SigningCredentialsHelperBase
    {
        public virtual SigningCredentials CreateSigningCredentials(SecurityKey securityKey, string securityAlgorithm = SecurityAlgorithms.HmacSha256Signature)
        {
            return new SigningCredentials(securityKey, securityAlgorithm);
        }
    }
}
