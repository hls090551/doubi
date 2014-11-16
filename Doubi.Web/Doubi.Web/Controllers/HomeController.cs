using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doubi.Web.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
           Doubi.Service.level.LevelService ls = new Doubi.Service.level.LevelService();
            var levels= ls.All_levels();
            ViewData["level"] = levels;
            return View();
        }
    }
}
