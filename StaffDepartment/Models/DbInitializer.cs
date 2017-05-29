using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StaffDepartment.Models
{
    public class DbInitializer: DropCreateDatabaseAlways<StaffDbContext>
    {
        protected override void Seed(StaffDbContext db)
        {
            Worker worker1 = new Worker { Name = "Ololo", LastName = "Trololol", Date = DateTime.Now, BCountry = "Pink Kingdom", BDate = DateTime.Now, BTown = "Pink town", INN = 30030030, Nationality = "Pilot", Patronymic = "Some good man", Sex = 'B' };
            WorkBook wb = new WorkBook { BeginDate = DateTime.Now, RecordID = 1, Worker = worker1 };
           
            db.Educations.Add(new Education { CollegeName = "El", DipNumber = 441899, SeriesOfDiplom = "KK", Speciality = "Bomg", Worker = worker1});
            base.Seed(db);
        }
    }
}