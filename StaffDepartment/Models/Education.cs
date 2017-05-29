using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class Education : IEducation
    {
        [Key]
        public int EId { get; set; }
        [Display(Name ="Название учебного завидения")]
        public string CollegeName { get; set; }
        [Display(Name = "Специальность")]
        public string Speciality { get; set; }
        [Display(Name = "Номер диплома")]
        public int DipNumber { get; set; }
        [Display(Name = "Серия диплома")]
        public string SeriesOfDiplom { get; set; }


        public Worker Worker { get; set; }

      //  public string SeriesOfDiplom { get; set; }

        [ForeignKey("Worker")]
        public int WId { get; set; }

        


        
    }
}