using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace PancakeProwler.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
