using Business.Models;
using Core.Business.Models.Security.Identity;

namespace Business.Services.Bases
{
    public interface IAuthService
    {
        KullaniciModel Register(KullaniciModel kullanici);
        KullaniciModel Login(KullaniciModel kullanici);
        Jwt CreateJwt(KullaniciParentModel kullanici, JwtOptions jwtOptions);
    }
}
