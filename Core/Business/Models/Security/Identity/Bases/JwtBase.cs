using System;

namespace Core.Business.Models.Security.Identity.Bases
{
    public abstract class JwtBase
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
