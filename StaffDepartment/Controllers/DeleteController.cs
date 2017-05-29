using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StaffDepartment.Controllers
{
    public class DeleteController : Controller
    {
        StaffDbContext _db;
        // GET: Delete
        public ActionResult Index(int Id)
        {
            using (_db = new StaffDbContext())
            {
                var user = _db.Workers.Include(w => w.WorkBook).Include(e => e.Educations).Include(p => p.Passports).Include(wp=>wp.WorkBook.WorkPlacess).Where(w=>w.WId == Id).Single();

               
                _db.Workers.Remove(user);
                
                    _db.SaveChanges();
               
            }
            return View();
        }


     

        public ActionResult Delete(int Id)
        {
            using (_db = new StaffDbContext())
            {
                var education = _db.Educations.Find(Id);
                if(education != null )
                {
                    _db.Educations.Remove(education);
                    _db.SaveChanges();
                    
                }

            }
            return View();
        }
    }
}