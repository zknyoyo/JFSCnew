using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFSCnew.Models
{
    public class Common
    {
        private YZSYEntities db = new YZSYEntities();
        public int GetPointsByName(string UserName)
        {
            if (!String.IsNullOrEmpty(UserName))
            {
                var points = db.Users.Where(u => u.name == UserName && u.active == true).FirstOrDefault().points;
                return points;
            }
            else
                return -1;
        }

    }
}