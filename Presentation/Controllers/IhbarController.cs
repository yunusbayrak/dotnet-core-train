using Business.Models.Filters;
using Business.Services.Bases;
using Business.Utils.Bases;
using Core.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class IhbarController : Controller
    {
        private readonly IIhbarService _ihbarService;
        private readonly IIhbarDurumuService _ihbarDurumuService;
        private readonly IControllerUtil _controllerUtil;

        public IhbarController(IIhbarService ihbarService, IIhbarDurumuService ihbarDurumuService, IControllerUtil controllerUtil)
        {
            _ihbarService = ihbarService;
            _ihbarDurumuService = ihbarDurumuService;
            _controllerUtil = controllerUtil;
        }

        public IActionResult Index(int id)
        {
            _controllerUtil.SetLiActive("Ihbar");
            ViewBag.LiActives = _controllerUtil.LiActives;
            IhbarFilterModel filter;
            if (id > 0 || HttpContext.Session.GetObject<IhbarFilterModel>("IhbarFilter") == null)
            {
                filter = new IhbarFilterModel
                {
                    Id = id
                };
            }
            else
            {
                filter = HttpContext.Session.GetObject<IhbarFilterModel>("IhbarFilter");
            }
            var model = new IhbarIndexViewModel
            {
                Ihbarlar = _ihbarService.GetIhbarlar(filter),
                IhbarDurumlari = new SelectList(_ihbarDurumuService.GetIhbarDurumlari(), "Id", "Adi", filter.IhbarDurumuId),
                Filter = filter
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IhbarFilterModel filter)
        {
            var model = _ihbarService.GetIhbarlar(filter);
            HttpContext.Session.SetObject("IhbarFilter", filter);
            return PartialView("_Ihbar", model);
        }
    }
}
