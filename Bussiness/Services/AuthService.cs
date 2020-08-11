using Business.Enums;
using Business.Models;
using Business.Services.Bases;
using Core.Business.Models.Security.Identity;
using Core.Business.Utils.Security.Identity.Bases;
using System;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly JwtUtilBase _jwtUtil;

        public AuthService(IKullaniciService kullaniciService, JwtUtilBase jwtUtil)
        {
            _kullaniciService = kullaniciService;
            _jwtUtil = jwtUtil;
        }

        public Jwt CreateJwt(KullaniciParentModel kullanici, JwtOptions jwtOptions)
        {
            try
            {
                var result = _jwtUtil.CreateJwt(kullanici, jwtOptions);
                return result;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public KullaniciModel Login(KullaniciModel kullanici)
        {
            try
            {
                var result = _kullaniciService.GetKullanici(kullanici.KullaniciAdi, kullanici.Sifre);
                return result;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public KullaniciModel Register(KullaniciModel kullanici)
        {
            try
            {
                kullanici.RolId = (int)RolEnum.Kullanici;
                kullanici.Aktif = true;
                _kullaniciService.AddKullanici(kullanici);
                var result = Login(kullanici);
                return result;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
