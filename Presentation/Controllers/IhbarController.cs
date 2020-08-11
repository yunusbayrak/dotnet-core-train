using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Bases;
using DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class IhbarController : Controller
    {
        private readonly IIhbarService _ihbarService;
        public IhbarController(IIhbarService ihbarService)
        {
            _ihbarService = ihbarService;
        }
        public IActionResult Index()
        {            
            return View(_ihbarService.GetIhbarlar());
        }
    }
}
