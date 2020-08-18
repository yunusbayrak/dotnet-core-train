using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Business.Utils.Bases;

namespace Presentation.Controllers.Demos
{
    /*
    HTTP Cookie is some piece of data which is stored in the user's browser.
    We can store users' related information in cookies and there are many other usages.

    Cookie options extends the cookie behavior in the browser.
    1) Domain - The domain you want to associate with cookie
    2) Path - Cookie Path
    3) Expires - The expiration date and time of the cookie
    4) HttpOnly - Gets or sets a value that indicates whether a cookie is accessible by client-side script or not.
    5) Secure - Transmit the cookie using Secure Sockets Layer (SSL) that is, over HTTPS only.  
    */

    public class CookiesController : Controller
    {
        private readonly IControllerUtil _controllerUtil;

        public CookiesController(IControllerUtil controllerUtil)
        {
            _controllerUtil = controllerUtil;
        }

        public IActionResult Index()
        {
            _controllerUtil.SetLiActive("Cookies");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var cookies = Request.Cookies.ToList();
            return View(cookies);
        }

        public IActionResult Set(string key, string value, int expiresInSeconds = 1200)
        {
            _controllerUtil.SetLiActive("Cookies");
            ViewBag.LiActives = _controllerUtil.LiActives;
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddSeconds(expiresInSeconds);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Set", "Cookies[" + key + "] = \"" + value + "\" set.");
        }

        public IActionResult Get(string key)
        {
            _controllerUtil.SetLiActive("Cookies");
            ViewBag.LiActives = _controllerUtil.LiActives;
            return View("Get", "Cookies[" + key + "] = \"" + Request.Cookies[key] + "\" returned.");
        }

        public IActionResult Remove(string key)
        {
            _controllerUtil.SetLiActive("Cookies");
            ViewBag.LiActives = _controllerUtil.LiActives;
            Response.Cookies.Delete(key);
            return View("Remove", "Cookies[" + key + "] removed.");
        }
    }
}