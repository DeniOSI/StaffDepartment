using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffDepartment.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        StaffDbContext db = new StaffDbContext();
        public ActionResult Print()
        {
            IEnumerable<Worker> workers = db.Workers;
            ViewBag.Workers = workers;
            return View();
        }
    }
}