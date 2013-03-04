using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using PancakeProwler.Web.Models;
using System.Collections.Generic;

namespace PancakeProwler.Web.Controllers
{
    public class ContactInformationController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /ContactInformation/

        public ActionResult Index()
        {
            return View(db.ContactInformaitons.ToList());
        }

        //
        // GET: /ContactInformation/Details/5

        public ActionResult Details(int id = 0)
        {
            ContactInformaiton contactinformaiton = db.ContactInformaitons.Find(id);
            if (contactinformaiton == null)
            {
                return HttpNotFound();
            }
            return View(contactinformaiton);
        }

        //
        // GET: /ContactInformation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ContactInformation/Create

        [HttpPost]
        public ActionResult Create(ContactInformaiton contactinformaiton)
        {
            if (ModelState.IsValid)
            {
                db.ContactInformaitons.Add(contactinformaiton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactinformaiton);
        }

        //
        // GET: /ContactInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ContactInformaiton contactinformaiton = db.ContactInformaitons.Find(id);
            if (contactinformaiton == null)
            {
                return HttpNotFound();
            }
            return View(contactinformaiton);
        }

        //
        // POST: /ContactInformation/Edit/5

        [HttpPost]
        public ActionResult Edit(ContactInformaiton contactinformaiton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactinformaiton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactinformaiton);
        }

        //
        // GET: /ContactInformation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ContactInformaiton contactinformaiton = db.ContactInformaitons.Find(id);
            if (contactinformaiton == null)
            {
                return HttpNotFound();
            }
            return View(contactinformaiton);
        }

        //
        // POST: /ContactInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInformaiton contactinformaiton = db.ContactInformaitons.Find(id);
            db.ContactInformaitons.Remove(contactinformaiton);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}