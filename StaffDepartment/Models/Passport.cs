using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Загран\\гражданина паспорт")]
        [MaxLength(50, ErrorMessage ="Превышенна длина поля")]
        public String PassportType { get; set; }
        
        [Display(Name = "Серия паспорта")]
        [MaxLength(50, ErrorMessage = "Превышенна длина поля")]
        public string Series { get; set; }
        [Display(Name = "Номер паспорта")]
        public int Number { get; set; }
        [Display(Name = "Кем выдан")]
        [MaxLength(50, ErrorMessage = "Превышенна длина поля")]
        public string Gave { get; set; }
        [Display(Name ="Дата регистрации паспорта")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Введите дату")]
        public DateTime DateOfIssue { get; set; }
        
        public Worker Worker { get; set; }
        [ForeignKey("Worker")]
        public int WorkerID { get; set; }
    }
}