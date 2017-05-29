using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class WorkBook
    {
        [Key]
        [ForeignKey("Worker")]
        public int WorkBookID { get; set; }
        [Display(Name ="Дата регистрации")]
        [DataType(DataType.Date, ErrorMessage ="Данные не соответствуют дате")]
        public DateTime BeginDate { get; set; }
        public int RecordID { get; set; }
      //  public string CompanyName { get; set; }
        public Worker Worker { get; set; }
              
        public ICollection<WorkPlace> WorkPlacess { get; set; }
        
    }
}