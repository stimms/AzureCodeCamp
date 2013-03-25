using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Web.Controllers
{
    public class HomeController : Controller
    {
        public IMealRepository MealRepository { get; set; }

        public ActionResult Index()
        {
            var meals = MealRepository.List().Where(x => x.Date >= DateTime.Today && x.Date < DateTime.Today.AddDays(1));
            return View(meals);
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
