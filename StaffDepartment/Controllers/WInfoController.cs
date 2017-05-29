using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StaffDepartment.Controllers
{
    public class WInfoController : Controller
    {
        StaffDbContext db;
        // GET: WInfo
     


        [HttpPost]
        public ActionResult Uinfo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Uinfo(int Id)
        {
            Worker worker;
            
            #region JoinTest
            using (db = new StaffDbContext())
            {

                 worker = db.Workers.Include(u => u.Passports).Include(u => u.Educations).Include(u => u.WorkBook).Include(wp=>wp.WorkBook.WorkPlacess).Where(u => u.WId == Id).FirstOrDefault();
                


            }
            return View(worker);
            #endregion
        }
        [HttpPost]
        public ActionResult UinfoS(int Id)
        {
            

            var getworker = getWorker(Id);
        
            var getworkbook = getWorkBook(getworker);
            ViewBag.workbook = getworkbook;

            ViewBag.workplace = workplace(Id);
            ViewBag.education = getEducation(Id);
            ViewBag.passport = getPassports(Id);

            return View();
        }

        private Worker getWorker(int id)
        {
            using (db = new StaffDbContext())
            {
                return db.Workers.Where(uid => uid.WId == id).FirstOrDefault();
            }
        }
        private WorkBook getWorkBook(Worker wor)
        {
            using (db = new StaffDbContext())
            {
                return db.WorkersBook.Where(wid => wid.WorkBookID == wor.WorkBookID).FirstOrDefault();
            }
        }

        private static IEnumerable<WorkPlace> workplace(int id) 
        {

            using (StaffDbContext db = new StaffDbContext())
            {
                try { 
                WorkBook wr = db.WorkersBook.Where(c => c.WorkBookID == id).FirstOrDefault();
                db.Entry(wr).Collection(c => c.WorkPlacess).Load();
                //if(wr!=null || wr.WorkPlacess != null )
                return wr.WorkPlacess;
                }
                catch { 
                return null;
                }
            }
        }
        private ICollection<Education> getEducation(int id)
        {
            using (StaffDbContext db = new StaffDbContext())
                try
            {
                Worker wr = db.Workers.Where(c => c.WId == id).FirstOrDefault();
                db.Entry(wr).Collection(c => c.Educations).Load();
                return wr.Educations;
            }
            catch
            {
                return null;
            }
        }
        private  IEnumerable<Passport> getPassports(int id)
        {
            using (StaffDbContext db = new StaffDbContext())
                try
                {
                    Worker wr = db.Workers.Where(c => c.WId == id).FirstOrDefault();
                    db.Entry(wr).Collection(c => c.Passports).Load();
                   
                    return wr.Passports;
                }
                catch
                {
                    return null;
                }

        }
       [HttpGet]
       public ActionResult PassportsList(int id)
        {
            ViewBag.uid = id;
            return View();
        }
        [HttpGet]
        public ActionResult AllInformation(int id)
        {
            Worker worker;

            #region JoinTest
            using (db = new StaffDbContext())
            {

                worker = db.Workers.Include(u => u.Passports).Include(u => u.Educations).Include(u => u.WorkBook).Include(wp => wp.WorkBook.WorkPlacess).Where(u => u.WId == id).FirstOrDefault();



            }
            return View(worker);
        }
     
    }
#endregion
}