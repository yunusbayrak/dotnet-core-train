using Business.Models;
using Business.Services.Bases;
using Core.Business.Models.Security.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public KullaniciController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(KullaniciModel kullanici)
        {
            var loginResult = _authService.Login(kullanici);
            if (loginResult == null)
            {
                return BadRequest("Geçersiz kullanıcı adı ve şifre.");
            }
            var section = _configuration.GetSection("JwtOptions");
            JwtOptions jwtOptions = new JwtOptions();
            section.Bind(jwtOptions);
            var tokenResult = _authService.CreateJwt(loginResult, jwtOptions);
            if (tokenResult == null)
            {
                return BadRequest("JWT oluşturulurken hata meydana geldi!");
            }
            return Ok(tokenResult);
        }

        [HttpPost("Register")]
        public IActionResult Register(KullaniciModel kullanici)
        {
            var registerResult = _authService.Register(kullanici);
            if (registerResult == null)
            {
                return BadRequest("Kullanıcı oluşturulurken hata meydana geldi!");
            }
            var section = _configuration.GetSection("JwtOptions");
            JwtOptions jwtOptions = new JwtOptions();
            section.Bind(jwtOptions);
            var tokenResult = _authService.CreateJwt(registerResult, jwtOptions);
            if (tokenResult == null)
            {
                return BadRequest("JWT oluşturulurken hata meydana geldi!");
            }
            return Ok(tokenResult);
        }
    }
}
