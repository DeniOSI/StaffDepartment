using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class StaffDbContext:DbContext
    {
        public StaffDbContext(): base("StaffDB")
        {

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkBook> WorkersBook { get; set; }
        public DbSet<WorkPlace> WorkPlacess { get; set; }
    }
}