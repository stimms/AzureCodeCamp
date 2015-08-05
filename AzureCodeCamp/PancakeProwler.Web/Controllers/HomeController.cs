using System.Web.Mvc;
using PancakeProwler.Data.Common.Repositories;
using Microsoft.ApplicationServer.Caching;

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

        public ActionResult CacheDemo()
        {

            var cache = new DataCache();
            ViewBag.CacheValue = cache.Get("key");
            return View();
        }

        [HttpPost]
        public ActionResult CacheDemo(string toCache)
        {
            var cache = new DataCache();
            cache.Put("key", toCache);
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

    }
}
