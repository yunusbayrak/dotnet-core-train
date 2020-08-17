using Business.Models;
using Business.Services.Bases;
using Business.Utils.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers.Tanimlar
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class IslemDurumuController : Controller
    {
        private readonly IIslemDurumuService _islemDurumuService;
        private readonly IControllerUtil _controllerUtil;

        public IslemDurumuController(IIslemDurumuService islemDurumuService, IControllerUtil controllerUtil)
        {
            _islemDurumuService = islemDurumuService;
            _controllerUtil = controllerUtil;
        }

        public IActionResult Index()
        {
            _controllerUtil.SetLiActive("IslemDurumu");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new IslemDurumuIndexViewModel
            {
                IslemDurumlari = _islemDurumuService.GetIslemDurumlari()
            };
            return View(model);
        }

        public IActionResult Create()
        {
            _controllerUtil.SetLiActive("IslemDurumu");
            ViewBag.LiActives = _controllerUtil.LiActives;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IslemDurumuModel islemDurumu)
        {
            if (ModelState.IsValid)
            {
                if (!_islemDurumuService.IslemDurumuExists(islemDurumu))
                {
                    _islemDurumuService.AddIslemDurumu(islemDurumu);
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "Girilen işlem durumu mevcuttur.";
            }
            _controllerUtil.SetLiActive("IslemDurumu");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new IslemDurumuCreateViewModel
            {
                IslemDurumu = islemDurumu
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            _controllerUtil.SetLiActive("IslemDurumu");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new IslemDurumuEditViewModel
            {
                IslemDurumu = _islemDurumuService.GetIslemDurumu(id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IslemDurumuModel islemDurumu)
        {
            if (ModelState.IsValid)
            {
                if (!_islemDurumuService.IslemDurumuExists(islemDurumu))
                {
                    _islemDurumuService.UpdateIslemDurumu(islemDurumu);
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "Girilen işlem durumu mevcuttur.";
            }
            _controllerUtil.SetLiActive("IslemDurumu");
            ViewBag.LiActives = _controllerUtil.LiActives;
            var model = new IslemDurumuEditViewModel
            {
                IslemDurumu = islemDurumu
            };
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var islemDurumu = _islemDurumuService.GetIslemDurumu(id);
            if (islemDurumu.FaaliyetSayisi == 0)
            {
                _islemDurumuService.DeleteIslemDurumu(id);
            }
            else
            {
                TempData["Message"] = "Silinmek istenen işlem durumuna ait faaliyetler bulunmaktadır.";
            }
            return RedirectToAction("Index");
        }
    }
}