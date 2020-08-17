using Business.Models;
using Business.Services.Bases;
using Business.Utils.Bases;
using Core.Business.Utils.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class OlayController : Controller
    {
        private readonly IOlayService _olayService;
        private readonly IIhbarService _ihbarService;
        private readonly TimeUtilBase _timeUtil;
        private readonly IControllerUtil _controllerUtil;

        public OlayController(IOlayService olayService, IIhbarService ihbarService, TimeUtilBase timeUtil, IControllerUtil controllerUtil)
        {
            _olayService = olayService;
            _ihbarService = ihbarService;
            _timeUtil = timeUtil;
            _controllerUtil = controllerUtil;
        }

        public IActionResult Index()
        {
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayIndexViewModel
            {
                Olaylar = _olayService.GetOlaylar()
            };
            return View(model);
        }

        public IActionResult Create()
        {
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayCreateViewModel
            {
                Olay = new OlayModel(),
                Ihbarlar = new MultiSelectList(_ihbarService.GetIhbarlar(), "Id", "Ozet"),
                Saatler = new SelectList(_timeUtil.Hours),
                Dakikalar = new SelectList(_timeUtil.Minutes)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OlayModel olay)
        {
            if (ModelState.IsValid)
            {
                _olayService.AddOlay(olay);
                return RedirectToAction("Index");
            }
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayCreateViewModel
            {
                Olay = new OlayModel(),
                Ihbarlar = new MultiSelectList(_ihbarService.GetIhbarlar(), "Id", "Ozet"),
                Saatler = new SelectList(_timeUtil.Hours),
                Dakikalar = new SelectList(_timeUtil.Minutes)
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayDetailsViewModel
            {
                Olay = _olayService.GetOlay(id)
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var olayModel = _olayService.GetOlay(id);
            var olaySaat = olayModel.Tarih.Value.Hour.ToString().PadLeft(2, '0');
            var olayDakika = olayModel.Tarih.Value.Minute.ToString().PadLeft(2, '0');
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayEditViewModel
            {
                Olay = olayModel,
                Ihbarlar = new MultiSelectList(_ihbarService.GetIhbarlar(), "Id", "Ozet", olayModel.IhbarIdleri),
                Saatler = new SelectList(_timeUtil.Hours, olaySaat),
                Dakikalar = new SelectList(_timeUtil.Minutes, olayDakika)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OlayModel olay)
        {
            if (ModelState.IsValid)
            {
                _olayService.UpdateOlay(olay);
                return RedirectToAction("Index");
            }
            var olayModel = _olayService.GetOlay(olay.Id);
            var olaySaat = olayModel.Tarih.Value.Hour.ToString().PadLeft(2, '0');
            var olayDakika = olayModel.Tarih.Value.Minute.ToString().PadLeft(2, '0');
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayEditViewModel
            {
                Olay = olayModel,
                Ihbarlar = new MultiSelectList(_ihbarService.GetIhbarlar(), "Id", "Ozet", olayModel.IhbarIdleri),
                Saatler = new SelectList(_timeUtil.Hours, olaySaat),
                Dakikalar = new SelectList(_timeUtil.Minutes, olayDakika)
            };
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _controllerUtil.SetLiActive("Olay");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new OlayDeleteViewModel
            {
                Olay = _olayService.GetOlay(id)
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _olayService.DeleteOlay(id);
            return RedirectToAction("Index");
        }
    }
}