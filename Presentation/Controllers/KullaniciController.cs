using Business.Models;
using Business.Services.Bases;
using Business.Utils.Bases;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Business.Enums;

namespace Presentation.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly IPersonelService _personelService;
        private readonly IControllerUtil _controllerUtil;

        public KullaniciController(IKullaniciService kullaniciService, IPersonelService personelService, IControllerUtil controllerUtil)
        {
            _kullaniciService = kullaniciService;
            _personelService = personelService;
            _controllerUtil = controllerUtil;
        }

        public IActionResult Login()
        {
            _controllerUtil.SetLiActive("Login");
            ViewBag.LiActives = _controllerUtil.LiActives;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(KullaniciModel kullanici)
        {
            if (ModelState.IsValid)
            {
                var kullaniciModel = _kullaniciService.GetKullanici(kullanici.KullaniciAdi, kullanici.Sifre);
                if (kullaniciModel != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, kullaniciModel.KullaniciAdi),
                        new Claim(ClaimTypes.Role, kullaniciModel.Rol.Adi)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                TempData["Message"] = "Geçersiz kullanıcı adı ve şifre.";
            }
            _controllerUtil.SetLiActive("Login");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new KullaniciLoginViewModel
            {
                Kullanici = kullanici
            };
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            _controllerUtil.SetLiActive("");
            ViewBag.LiActives = _controllerUtil.LiActives;
            return View();
        }

        public IActionResult Register()
        {
            _controllerUtil.SetLiActive("Register");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new KullaniciRegisterViewModel
            {
                Personeller = new SelectList(_personelService.GetPersoneller(), "Id", "AdSoyad")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(KullaniciModel kullanici)
        {
            if (ModelState.IsValid)
            {
                if (_kullaniciService.KullaniciExists(kullanici))
                {
                    TempData["Message"] = "Girilen kullanıcı adı mevcuttur.";
                }
                else if (_kullaniciService.PersonelExists(kullanici))
                {
                    TempData["Message"] = "Seçilen personelin kullanıcı kaydı mevcuttur.";
                }
                else
                {
                    kullanici.RolId = (int) RolEnum.Kullanici;
                    _kullaniciService.AddKullanici(kullanici);
                    TempData["Message"] = "Yeni kullanıcı kaydı başarıyla gerçekleştirilmiştir. Kayıt onaylandıktan sonra sisteme giriş yapabilirsiniz.";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["Message"] = "Kullanıcı adı ve şifre girilmelidir.";
            }
            _controllerUtil.SetLiActive("Register");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new KullaniciRegisterViewModel
            {
                Personeller = new SelectList(_personelService.GetPersoneller(), "Id", "IsimSoyisim")
            };
            return View(model);
        }
    }
}