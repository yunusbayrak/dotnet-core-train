using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewComponents
{
    public class IhbarDurumuViewComponent : ViewComponent
    {
        private IIhbarDurumuService _ihbarService { get; set; }
        public IhbarDurumuViewComponent(IIhbarDurumuService ihbarService)
        {
            _ihbarService = ihbarService;
        }
        public ViewViewComponentResult Invoke()
        {
            var ihbarDurumlari = _ihbarService.GetIhbarDurumlari().Select(c => new SelectListItem() { Text = c.Adi, Value = c.Id.ToString() })
        .ToList();
            return View("/Views/Shared/Components/IhbarDurumu.cshtml",ihbarDurumlari);
        }

    }
}
