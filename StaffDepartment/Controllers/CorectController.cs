using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.IO;

namespace StaffDepartment.Controllers
{
    public class CorectController : Controller
    {
        // GET: Corect
        public ActionResult Index(int Id, string choise)
        {
            switch (choise)
            {
                case "information":
                    {
                        Worker worker = getWorker(Id);
                        return View(worker);
                        break;
                    }
                case "education":

                    {

                       return educationUpdate(Id);
                        break;
                    }
                case "workplace":
                    {
                        return RedirectToAction("WorkPlace", "Update", new { Id = Id });
                        break;
                    }
                default:
                    {
                        return Redirect("Index");
                    }
            }
            return View();
        }

        public async Task<ActionResult> UserDetail(int id)
        {
            Worker worker;
            using (StaffDbContext _db = new StaffDbContext())
            {
                worker = await _db.Workers.FindAsync(id);
                if(worker!= null)
                {
                    return View(worker);

                }
                else
                {
                    ModelState.AddModelError("", "Работник не найден");
                }

            }
            return View();
        }

        public ActionResult educationUpdate(int id)
        {
            IEnumerable<Education> education = new List<Education>() ;
            using (StaffDbContext _db = new StaffDbContext())
            {
                ViewBag.wid = id;
                education = _db.Educations.Where(w => w.WId == id).ToList();
            }
            return View(education);
        } //Вывод списка оконченых образований

        [HttpPost]
        public ActionResult Index(Worker worker, HttpPostedFileBase uploadImage)
        {
            byte[] imagedata;
            using (StaffDbContext _db = new StaffDbContext())
            {
                if(worker!=null && uploadImage!=null)
                {
                    using (var brp = new BinaryReader(uploadImage.InputStream))
                    {
                         imagedata = brp.ReadBytes(uploadImage.ContentLength);
                    }
                    worker.Photo = imagedata;
                        _db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Uinfo", "WInfo", new { Id = worker.WId });
                }
            }
                return View(worker);
            
        } //Сохранение изминений учетной записи пользователя

        //[HttpPost]
        #region EducationCollectionWrong
        //public ActionResult educationUpdate(ICollection<Education> education)
        //{
        //    using (StaffDbContext _db = new StaffDbContext())
        //    {
        //        if (education != null)
        //        {
        //            _db.Entry(education).State = System.Data.Entity.EntityState.Modified;
        //            _db.SaveChanges();
        //            return RedirectToAction("Uinfo", "WInfo", new { Id = education.ElementAt(0).WId });
        //        }
        //    }
        //    return View(education);
        //} 
        #endregion

        private Worker getWorker(int id)
        {
            Worker worker;
            using(StaffDbContext _db = new StaffDbContext())
            {
                worker = _db.Workers.Where(w => w.WId == id).FirstOrDefault();
            }
            return worker;
        } //Получение пользователя по ИД

        [HttpPost]
        public ActionResult CorrectEducation(Education ed)
        {
            if(ModelState.IsValid)
            {
                using (StaffDbContext _db = new StaffDbContext())
                {
                    _db.Entry(ed).State = System.Data.Entity.EntityState.Modified;
                    bool saveFiled;
                    do
                    {
                        saveFiled = false;


                        try
                        {
                            _db.SaveChanges();
                            return RedirectToAction("educationUpdate", "Corect", new { id = ed.WId });
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFiled = true;
                            ex.Entries.Single().Reload();
                        }
                    } while (saveFiled);
                }
                
            }
            return View();
        } //Сохранение изминений мест учебы
        [HttpGet]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                Education education = await _db.Educations.FindAsync(id);
                int WID = education.WId;
                if (education != null)
                {
                    try
                    {
                        _db.Entry(education).State = EntityState.Deleted;
                        _db.SaveChanges();
                        return RedirectToAction("educationUpdate", "Corect", new { id = WID });
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {

                        return View();
                    }

                }
                return View();
            }
        }  //Удаление записи об образовании


        //создание записи об образовании
        [HttpGet]
        public async Task<ActionResult> CreateEducation(int id)
        {
            ViewBag.wid = id;
            return  View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateEducation(Education model)
        {
            if(ModelState.IsValid)
            {
                using (StaffDbContext _db = new StaffDbContext())
                {
                    _db.Educations.Add(model);
                    try
                    {
                       await _db.SaveChangesAsync();
                       return RedirectToAction("educationUpdate", "Corect", new { id = model.WId });
                    }
                    catch (Exception)
                    {

                        return View();
                    }
                }
            }
            return View();
        } //Создание изминения образования

        [HttpGet]
        public ActionResult PassportUpdate(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            { 
                ViewBag.wid = id;
                ICollection<Passport> passport = _db.Passports.Where(p => p.WorkerID == id).ToList();
                if(passport != null)
                {
                    return View(passport);
                }
                    }
            return View();
        } //Получение списка паспортов работника

        #region Редактирование паспорта
        [HttpGet]
        public async Task<ActionResult> EditRecordPassportAsync(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                ViewBag.wid = id;
                Passport passport = await _db.Passports.Where(p => p.WorkerID == id).FirstOrDefaultAsync();
                if (passport != null)
                {
                    return View(passport);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditRecordPassportAsync(Passport model)
        {
            if (ModelState.IsValid)
            {
                using (StaffDbContext _db = new StaffDbContext())
                {
                    _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    bool saveFiled;
                    do
                    {
                        saveFiled = false;


                        try
                        {
                            await _db.SaveChangesAsync();
                            return RedirectToAction("PassportUpdate", "Corect", new { id = model.WorkerID });
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFiled = true;
                            await ex.Entries.Single().ReloadAsync();
                        }
                    } while (saveFiled);
                }

            }
            return View();
        }
        #endregion

        #region Добавление и удаление паспорта
        public async Task<ActionResult> DeletePassport(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                var passport = await _db.Passports.Where(pa => pa.Id == id).FirstOrDefaultAsync();
                if (passport != null)
                {
                    int ID = passport.WorkerID;
                    _db.Entry(passport).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    ViewBag.mesaga = "Запись удаленна";
                    return RedirectToAction("PassportUpdate", "Corect", new { id = ID });
                }
                ModelState.AddModelError("Passport", "Записи не существует");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPassport(Passport passport)
        {
            if (ModelState.IsValid)
            {
                using (StaffDbContext _db = new StaffDbContext())
                {
                    _db.Passports.Add(passport);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("PassportUpdate", "Corect", new { id = passport.WorkerID });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddPassport(int id)
        {
            ViewBag.wid = id;
            return View();
        }

        #endregion

        #region Изминение трудовой книжки
        [HttpGet]
        public async Task<ActionResult> workBookEditAsync(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                ViewBag.wid = id;
                WorkBook workbook = await _db.WorkersBook.Where(p => p.WorkBookID == id).FirstAsync();
                if (workbook != null)
                {
                    return View(workbook);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> workBookEditAsync(WorkBook model)
        {
            if (ModelState.IsValid)
            {
                using (StaffDbContext _db = new StaffDbContext())
                {
                    _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    bool saveFiled;
                    do
                    {
                        saveFiled = false;


                        try
                        {
                            await _db.SaveChangesAsync();
                            return RedirectToAction("workBookEditAsync", "Corect", new { id = model.WorkBookID });
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFiled = true;
                            await ex.Entries.Single().ReloadAsync();
                        }
                    } while (saveFiled);
                }

            }
            return View();
        }
        #endregion

        #region Места роботы
        [HttpGet]
        public async Task<ActionResult> wpListAsync(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                var wp = await _db.WorkPlacess.Where(w => w.WokrBookID == id).ToListAsync();
                if (wp != null)
                {
                    ViewBag.wid = id;
                    return View(wp);
                }
                ModelState.AddModelError("", "Нет объектов");
            }
            return View();
        } //Получение списка мест работы 

        [HttpGet]
        public async Task<ActionResult> EditWP(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                var wp = await _db.WorkPlacess.Where(w => w.Id == id).FirstAsync();
                int iid = wp.WokrBookID;
                if (wp != null)
                {
                    ViewBag.wid = iid;
                    return View(wp);
                }
                ModelState.AddModelError("", "Нет объектов");
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditWP(WorkPlace model)
        {
            if(ModelState.IsValid)
            { 
            using (StaffDbContext _db = new StaffDbContext())
            {
                    try
                    {

                        _db.Entry(model).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                        return RedirectToAction("wpListAsync", "Corect", 
                            new { id = model.WokrBookID });


                    }
                    catch (Exception)
                    {

                        return View();
                    }
            }
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AddWP(int id)
        {
            ViewBag.wi = id;
            ViewBag.lsls = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddWP(WorkPlace model)
        {
            if(ModelState.IsValid)
            {
                using(StaffDbContext _db = new StaffDbContext())
                {
                    int ID = model.WokrBookID;
                    _db.WorkPlacess.Add(model);
                    await _db.SaveChangesAsync();
                    return  RedirectToAction("wpListAsync", "Corect", new { id = ID });
                }

            }
            return View();
        }

        public async Task<ActionResult> DeleteWP(int id)
        {
            using (StaffDbContext _db = new StaffDbContext())
            {
                var workplace = await _db.WorkPlacess.Where(pa => pa.Id == id).FirstOrDefaultAsync();
                if (workplace != null)
                {
                    int ID = workplace.WokrBookID ;
                    _db.Entry(workplace).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    ViewBag.mesaga = "Запись удаленна";
                    return RedirectToAction("wpListAsync", "Corect", new { id = ID });
                }
                ModelState.AddModelError("WorkPlace", "Записи не существует");
            }
            return View();
        }

        #endregion
    }
}