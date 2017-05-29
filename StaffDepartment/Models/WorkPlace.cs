using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class WorkPlace
    {

        [Key]
        public int Id { get; set; }
        [Display(Name ="Занимаемая должность")]
        public string Position { get; set; }

        [Display(Name ="Адресс и название места работы")]
        public string CompanyName { get; set; }

        [Display(Name = "Дата начала роботы")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Дата увольнения")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Причина увольнения")]
        public string ReasonForLeaving { get; set; }

        public WorkBook WorkBook { get; set; }
        [ForeignKey("WorkBook")]
        public int WokrBookID { get; set; }

    }
}