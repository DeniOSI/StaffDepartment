using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StaffDepartment.Controllers
{
    public class UpdController : Controller
    {
        StaffDbContext _db;
        // GET: Upd
        public ActionResult Index(int Id)
        {
#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
            int i = 0;
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется
            Worker worker;
            UserInfoModel model = new UserInfoModel();
            using (_db = new StaffDbContext())
            {
                worker = _db.Workers.Include(u => u.Passports).Include(u => u.Educations).Include(u => u.WorkBook).Include(wl => wl.WorkBook.WorkPlacess).Where(u => u.WId == Id).FirstOrDefault();
                #region WrongMethod
                //    var workPlace = _db.WorkPlacess.Where(w => w.WokrBookID == worker.WorkBook.WorkBookID).ToList();
                //    model.WID = worker.WId;
                //    model.Name = worker.Name;
                //    model.LastName = worker.LastName;
                //    model.Patnonymic = worker.Patronymic;
                //    model.INN = worker.INN;
                //    model.DataRegistration = worker.Date;
                //    model.BDate = worker.BDate;
                //    model.Addr = worker.Addr;
                //    model.Nationality = worker.Nationality;
                //    foreach (var item in worker.Educations)
                //    {
                //        model.EducationCollegeName.Add(item.CollegeName);
                //        model.EducationDipNumber.Add(item.DipNumber);
                //        model.EducationSeriesOfDiplom.Add(item.SeriesOfDiplom);
                //        model.EducationSpeciality.Add(item.Speciality);
                //        model.Educations.Add(new Education
                //        {
                //            CollegeName = item.CollegeName,
                //            DipNumber = item.DipNumber,
                //            SeriesOfDiplom = item.SeriesOfDiplom,
                //            Speciality = item.Speciality,

                //        });
                //    }

                //    foreach (var item in worker.Passports)
                //    {
                //        model.PassportGave = item.Gave;
                //        model.PassportDateOfIssue = item.DateOfIssue;
                //        model.PassportNumber = item.Number;
                //        model.PassportSeries = item.Series;
                //        model.Passports.Add(new Passport

                //        {
                //        DateOfIssue = item.DateOfIssue,
                //        Gave = item.Gave,
                //        Number = item.Number,
                //        Series = item.Series,
                //        });
                //    }

                //    model.WorkBookNumber = worker.WorkBook.WorkBookID;
                //    model.WorkBookDataRegistration = worker.WorkBook.BeginDate;
                //    model.WP = workPlace;

                //} 
                #endregion
                return View(worker);
            }
        }
        [HttpPost]
        public ActionResult Index(Worker model)
        {

            #region WrongCollection
            //Worker worker;
            //ICollection<Education> education = new List<Education>();
            //ICollection<Passport> passport = new List<Passport>();
            //ICollection<WorkPlace> workplace = new List<WorkPlace>(); 
            #endregion
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.INN, model.Passports.ElementAt(0).Number, model.Passports.ElementAt(0).Series))
                    //Добавляем информацию о образовании
                    using (_db = new StaffDbContext())
                    {
                        #region WrongMethod
                        //for (int i = 0; i < model.WorkPlaPosition.Count; i++)
                        //{
                        //    workplace.Add(new WorkPlace
                        //    {
                        //        CompanyName = model.WorkPlaceCompanyName.ElementAt(i),
                        //        Position = model.WorkPlaPosition.ElementAt(i),
                        //        BeginDate = model.WorkPlaceBegin.ElementAt(i),
                        //        FinishDate = model.WorkPlaceFinish.ElementAt(i),
                        //        ReasonForLeaving = model.WorkPlaceReasonForLeaving.ElementAt(i),

                        ////    });
                        //}
                        //passport.Add(new Passport
                        //{
                        //    Number = model.PassportNumber,
                        //    Series = model.PassportSeries,
                        //    Gave = model.PassportGave,
                        //    DateOfIssue = model.PassportDateOfIssue,
                        //});
                        //for (int i = 0; i < model.EducationCollegeName.Count; i++)
                        //{
                        //    education.Add(new Education
                        //    {
                        //        CollegeName = model.EducationCollegeName.ElementAt(i),
                        //        DipNumber = model.EducationDipNumber.ElementAt(i),
                        //        SeriesOfDiplom = model.EducationSeriesOfDiplom.ElementAt(i),
                        //        Speciality = model.EducationSeriesOfDiplom.ElementAt(i)
                        //    });
                        //}
                        //worker = new Worker
                        //{
                        //    Name = model.Name,
                        //    Addr = model.Addr,
                        //    Patronymic = model.Patnonymic,
                        //    BDate = model.BDate,
                        //    Date = DateTime.Now.Date,
                        //    INN = model.INN,
                        //    LastName = model.LastName,
                        //    Nationality = model.Nationality,
                        //    WorkBook =
                        //   new WorkBook
                        //   {
                        //       BeginDate = model.WorkBookDataRegistration,
                        //       WorkPlacess = workplace
                        //   },
                        //    Educations = education,
                        //    Passports = passport
                        //}; 
                        #endregion
                        _db.Entry(model).State = EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("Uinfo", "WInfo", new { Id = model.WId});
                    }
            }
            return View();
        }
        private bool ValidateUser(int iNN, int passportNumber, string passportSeries)
        {
            bool flag = true;
            using (StaffDbContext _db = new StaffDbContext())
            {
                var inn = _db.Workers.Where(w => w.INN == iNN).First();
                var passport = _db.Passports.Where(p => p.Number == passportNumber && p.Series == passportSeries).FirstOrDefault();
                if (inn != null && passport != null)
                    flag = false;
            }
            return flag;
        } // Проверка дубликата работника
    }
}