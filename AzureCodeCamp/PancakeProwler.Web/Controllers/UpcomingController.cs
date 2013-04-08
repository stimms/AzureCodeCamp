using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Web.Controllers
{
    public class UpcomingController : Controller
    {
        public IMealRepository MealRepository { get; set; }

        public ActionResult Index()
        {
            return View(MealRepository.List());
        }

    }
}
