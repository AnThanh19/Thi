using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thi.Models;

namespace Thi.Controllers
{
    public class CongNhanController : Controller
    {
        public IActionResult LietKe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Show(int soTrieuChung)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            return View(context.Show(soTrieuChung));
        }
    
    }
}
