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
    public class UsersController : Controller
    {
        private YZSYEntities db = new YZSYEntities();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Employees);
            return View(users.ToList());
        }


        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "Id","job_num",users.employee_id);
            return View(users);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "Id", "job_num", users.employee_id);
            return View(users);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}