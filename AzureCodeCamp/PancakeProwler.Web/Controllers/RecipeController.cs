using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Web.Controllers
{
    public class RecipeController : Controller
    {

        public IRecipeRepository RecipeRepository { get; set; }
        //
        // GET: /Recipe/

        public ActionResult Index()
        {
            return View(RecipeRepository.List());
        }

        //
        // GET: /Recipe/Details/5

        public ActionResult Details(Guid id)
        {
            Recipe recipe = RecipeRepository.GetById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // GET: /Recipe/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recipe/Create

        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.Id = Guid.NewGuid();
                RecipeRepository.Create(recipe); 
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        //
        // GET: /Recipe/Edit/5

        public ActionResult Edit(Guid id)
        {
            Recipe recipe = RecipeRepository.GetById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // POST: /Recipe/Edit/5

        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                RecipeRepository.Edit(recipe);
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

    }
}