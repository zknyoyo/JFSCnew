using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFSCnew.Models;

namespace JFSCnew.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private YZSYEntities db = new YZSYEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Gifts = db.Gifts.Where(g => g.active == true).ToList();
            return View();
        }

        public ActionResult Gift(int id)
        {
            ViewBag.Gift = db.Gifts.Find(id);
            return View();
        }

        public JsonResult Exchange(int gift_id, int amount)
        {
            Gifts gifts = db.Gifts.Find(gift_id);
            Users users = db.Users.Where(u => u.active == true && u.name == User.Identity.Name).FirstOrDefault();
            if (gifts != null)
            {
                if (users.points >= gifts.price * amount)
                {
                    Records records = new Records { active = true, amount = amount, buyer_id = users.Id, cost = gifts.price * amount, createddt = DateTime.Now, gift_id = gifts.Id };
                    users.points = users.points - gifts.price * amount;
                    db.Records.Add(records);
                    db.SaveChanges();
                    return Json(new { result = true, amount = amount, price = gifts.price });
                }
                else
                {
                    return Json(new { result = "tooless" });

                }
            }
            else
                return Json(new { result = false });

        }
        [Authorize(Users = "admin")]
        public ActionResult RecordsList()
        {
            return View();
        }

        public PartialViewResult GetRecordsList(DateTime start, DateTime end)
        {
            var allUsers = db.Users.Include("Records").Include("Employees").Where(u => u.active == true).ToList();
            ViewBag.start = start;
            ViewBag.end = end.AddDays(1);
            ViewBag.gifts = db.Gifts.Where(g => g.active == true).ToList(); 
            return PartialView(@"dynamic/GetRecordsList", allUsers);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
