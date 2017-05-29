using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffDepartment.Controllers
{
    public class FindController : Controller
    {
        StaffDbContext db = new StaffDbContext();
        // GET: Find
        [HttpGet]
        public ActionResult Find()
        {
           return View();
        }
       [HttpPost]
       public ActionResult Find(string findStr)
        {
            
                var find = db.Workers.Where(fs => fs.Name == findStr|| fs.LastName == findStr);

                ViewBag.Finds = find;

                return View();
            
        }
    }
}