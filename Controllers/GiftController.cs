using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFSCnew.Models;

namespace JFSCnew.Controllers
{
    public class GiftController : Controller
    {
        private YZSYEntities db = new YZSYEntities();

        //
        // GET: /Gift/
        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            return View(db.Gifts.ToList());
        }

        //
        // GET: /Gift/Details/5

        public ActionResult Details(int id = 0)
        {
            Gifts gifts = db.Gifts.Find(id);
            if (gifts == null)
            {
                return HttpNotFound();
            }
            return View(gifts);
        }

        //
        // GET: /Gift/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gift/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gifts gifts)
        {
            if (ModelState.IsValid)
            {
                db.Gifts.Add(gifts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gifts);
        }

        //
        // GET: /Gift/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gifts gifts = db.Gifts.Find(id);
            if (gifts == null)
            {
                return HttpNotFound();
            }
            return View(gifts);
        }

        //
        // POST: /Gift/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gifts gifts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gifts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gifts);
        }

        //
        // GET: /Gift/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gifts gifts = db.Gifts.Find(id);
            if (gifts == null)
            {
                return HttpNotFound();
            }
            return View(gifts);
        }

        //
        // POST: /Gift/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gifts gifts = db.Gifts.Find(id);
            db.Gifts.Remove(gifts);
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