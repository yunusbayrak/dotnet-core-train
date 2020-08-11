using Core.Business.Extensions;
using Core.Business.Helpers.Security.Identity;
using Core.Business.Models.Security.Identity;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Core.Business.Utils.Security.Identity.Bases
{
    public abstract class JwtUtilBase
    {
        public virtual Jwt CreateJwt(KullaniciParentModel kullanici, JwtOptions jwtOptions)
        {
            try
            {
                var securityKeyHelper = new SecurityKeyHelper();
                var securityKey = securityKeyHelper.CreateSecurityKey(jwtOptions.SecurityKey);
                var signingCredentialsHelper = new SigningCredentialsHelper();
                var signingCredentials = signingCredentialsHelper.CreateSigningCredentials(securityKey);
                var claimList = new List<Claim>();
                claimList.AddUserNameIdentifier(kullanici.Guid);
                claimList.AddUserName(kullanici.KullaniciAdi);
                if (kullanici.Rol != null)
                {
                    claimList.AddRoleNames(new string[] { kullanici.Rol.Adi });
                }
                var expiration = DateTimeUtil.AddTimeToDate(DateTime.Now, 0, jwtOptions.JwtExpirationMinutes);
                var jwtSecurityToken = new JwtSecurityToken(jwtOptions.Issuer, jwtOptions.Audience, claimList,
                    DateTime.Now, expiration, signingCredentials);
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
                var jwt = new Jwt()
                {
                    Token = token,
                    Expiration = expiration
                };
                return jwt;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public virtual List<Claim> GetClaimsFromJwt(string jwt)
        {
            try
            {
                var claims = new List<Claim>();
                var payload = jwt.Split('.')[1];
                switch (payload.Length % 4)
                {
                    case 2:
                        payload += "==";
                        break;
                    case 3:
                        payload += "=";
                        break;
                }
                var jsonBytes = Convert.FromBase64String(payload);
                var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
                keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
                if (roles != null)
                {
                    if (roles.ToString().Trim().StartsWith("["))
                    {
                        var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
                        foreach (var parsedRole in parsedRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                    }
                    keyValuePairs.Remove(ClaimTypes.Role);
                }
                return claims;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
