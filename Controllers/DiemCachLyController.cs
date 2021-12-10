using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thi.Models;

namespace Thi.Controllers
{
    public class DiemCachLyController : Controller
    {
        public IActionResult Them()
        {
            return View();
        }
        

        [HttpPost]
        public string Create(DiemCachLyModel DCL)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            if (context.Create(DCL) != 0)
            {
                return "Thêm thành công";
            }
            return "Thất bại";
        }

        public IActionResult Show()
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            return View(context.getDiemCachLy());
        }

        [HttpPost]
        public IActionResult LietKe(string madiemcachly)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            return View(context.getCNCL(madiemcachly));
        }
        public IActionResult Delete(string macongnhan, CongNhanModel cn)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            if (context.DeleteCN(macongnhan, cn) != 0)
            {
                return Redirect("/DiemCachly/Show");
            }
            return Redirect("/DiemCachly/Show");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewCN(string macongnhan)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Thi.Models.DbContext)) as DbContext;
            return View(context.DetailCN(macongnhan));
        }
    }
}
