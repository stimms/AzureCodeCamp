using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Web.Controllers
{
    public class MealController : Controller
    {
        public IMealRepository MealRepository { get; set; }

        //
        // GET: /Meal/
        public ActionResult Index()
        {
            return View(MealRepository.List());
        }

       
        public ActionResult Details(Guid id)
        {
            Meal meal = MealRepository.GetById(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        //
        // GET: /Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Meal/Create
        [HttpPost]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                meal.Id = Guid.NewGuid();
                MealRepository.Create(meal);
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        //
        // GET: /Meal/Edit/5
        public ActionResult Edit(Guid id)
        {
            Meal meal = MealRepository.GetById(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        //
        // POST: /Meal/Edit/5
        [HttpPost]
        public ActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                MealRepository.Edit(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

    }
}