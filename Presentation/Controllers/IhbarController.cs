using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class IhbarController : Controller
    {
        private JkiContext _dbcontext;
        public IhbarController(DbContext dbContext)
        {
            _dbcontext = dbContext as JkiContext;
        }
        public IActionResult Index()
        {            
            return View(_dbcontext.Ihbar.Include(x=>x.IhbarDurumu).ToList());
        }
    }
}
