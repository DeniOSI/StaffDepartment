using StaffDepartment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffDepartment.Controllers
{
    public class AddUserController : Controller
    {
        StaffDbContext _db;
        // GET: AddUser
        public ActionResult Add()
        {
          
            return View();

        }
        [HttpPost]
        public ActionResult Add(UserInfoModel model, HttpPostedFileBase uploadImage)
        {
            Worker worker;
            byte[] imageData = null;
            
            ICollection<Education> education = new List<Education>();
            ICollection<Passport> passport = new List<Passport>();
            ICollection<WorkPlace> workplace = new List<WorkPlace>();

            if (ModelState.IsValid && uploadImage!=null)
            {
                
                //if(ValidateUser(model.INN, model.PassportNumber, model.PassportSeries))
                //Добавляем информацию о образовании
                using (_db = new StaffDbContext())
                {
                   for (int i = 0; i < model.WorkPlaPosition.Count; i++)
                    {
                        workplace.Add(new WorkPlace
                        {
                            CompanyName = model.WorkPlaceCompanyName.ElementAt(i),
                            Position = model.WorkPlaPosition.ElementAt(i),
                            BeginDate = model.WorkPlaceBegin.ElementAt(i),
                            FinishDate = model.WorkPlaceFinish.ElementAt(i),
                            ReasonForLeaving = model.WorkPlaceReasonForLeaving.ElementAt(i),

                        });
                    }
                    passport.Add(new Passport
                    {
                        Number = model.PassportNumber,
                        Series = model.PassportSeries,
                        Gave = model.PassportGave,
                        DateOfIssue = model.PassportDateOfIssue,
                    });
                    for (int i = 0; i < model.EducationCollegeName.Count; i++)
                    {
                        education.Add(new Education
                        {
                            CollegeName = model.EducationCollegeName.ElementAt(i),
                            DipNumber = model.EducationDipNumber.ElementAt(i),
                            SeriesOfDiplom = model.EducationSeriesOfDiplom.ElementAt(i),
                            Speciality = model.EducationSeriesOfDiplom.ElementAt(i)
                        });
                    }
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    worker = new Worker
                    {
                        Photo = imageData,
                        Name = model.Name,
                        Addr = model.Addr,
                        Patronymic = model.Patnonymic,
                        BDate = model.BDate,
                        Date = DateTime.Now.Date,
                        INN = model.INN,
                        LastName = model.LastName,
                        Nationality = model.Nationality,
                        WorkBook =
                        new WorkBook
                        {
                            BeginDate = model.WorkBookDataRegistration,
                            WorkPlacess = workplace
                        },
                        Educations = education,
                        Passports = passport
                    };
                    _db.Workers.Add(worker);
                    _db.SaveChanges();
                    return RedirectPermanent("/Print/Print");
                }
        
            }
            return View(model);
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
    