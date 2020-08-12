using Business.Models;
using Business.Models.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Presentation.Models
{
    public class IhbarIndexViewModel
    {
        public List<IhbarModel> Ihbarlar { get; set; }
        public SelectList IhbarDurumlari { get; set; }
        public IhbarFilterModel Filter { get; set; }
    }
}
