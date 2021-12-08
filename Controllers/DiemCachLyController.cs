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
    }
}
