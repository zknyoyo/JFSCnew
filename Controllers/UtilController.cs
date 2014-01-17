using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFSCnew.Models;


namespace JFSCnew.Controllers
{
    public class UtilController : Controller
    {
        private YZSYEntities db = new YZSYEntities();
        //
        // GET: /Util/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowPoints()
        {
            var points = (new Common()).GetPointsByName(User.Identity.Name);
            return Json(new { points = points });
        }
    }
}
