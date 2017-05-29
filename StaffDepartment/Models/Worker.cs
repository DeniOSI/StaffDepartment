using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class Worker
    {
        [Key]
        public int WId { get; set; }
        [Display(Name ="Имя")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
        
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
        
        public string LastName { get; set; }

        [Display(Name = "Адрес")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
        
        public string Addr { get; set; }

        [Display(Name = "Отчество")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
        
        public string Patronymic { get; set; }

        [Display(Name = "Пол")]
        public char Sex { get; set; }

        [Display(Name = "Идентификационный номер")]
        
        public int INN { get; set; }

        [Display(Name = "Дата регистрации")]
        public DateTime Date { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BDate { get; set; }

        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }



        [Display(Name = "Место рождения")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
      
        public string BCountry { get; set; }

        [Display(Name = "Национальность")]
        [MaxLength(50, ErrorMessage = "Максимальный размер поля превышен")]
      
        public string Nationality { get; set; }

        public  ICollection<Passport> Passports { get; set; }
        public  ICollection<Education> Educations { get; set; }
        

        public WorkBook WorkBook { get; set; }
        [ForeignKey("WorkBook")]
        public int WorkBookID { get; set; }

        public string BTown { get; set; }
        //work book one-to-one





    }
}