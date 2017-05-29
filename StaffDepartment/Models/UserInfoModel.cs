using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffDepartment.Models
{
    public class UserInfoModel
    {
        public UserInfoModel()
        {
            EducationCollegeName = new List<string>();
            EducationSpeciality = new List<string>();
            EducationDipNumber = new List<int>();
            EducationSeriesOfDiplom = new List<string>();
            WorkPlaPosition = new List<string>();
            WorkPlaceBegin = new List<DateTime>();
            WP = new List<WorkPlace>();
            WorkPlaceFinish = new List<DateTime>();
            WorkPlaceReasonForLeaving = new List<string>();
             
            Passports = new List<Passport>();
            Educations = new List<Education>();

            WorkBooks = new List<WorkBook>();

    }
        public int WID { get; set; }
        //Информация о работнике
        [Required]
        [Display(Name ="Имя")]
        [MaxLength(30, ErrorMessage ="Превышенна максимальная длина поля")]
        public string Name { get; set; }


        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [MaxLength(30, ErrorMessage = "Превышенна максимальная длина поля")]
        public string  LastName { get; set; }
        
        [Display(Name = "Отчество")]
        [MaxLength(30, ErrorMessage = "Превышенна максимальная длина поля")]
        public string Patnonymic { get; set; }

        [Required]
        [Display(Name = "Идентификационный номер")]
        public int INN { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина поля")]
        public string Addr { get; set; }

        [Required]
        [Display(Name ="Дата рагистрации работника")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataRegistration { get; set; }

        [Required]
        [Display(Name = "День рождения работника")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BDate { get; set; }

        [Required]
        [Display(Name = "Национальность")]
        [MaxLength(30, ErrorMessage = "Превышенна максимальная длина поля")]
        public string Nationality { get; set; }
       
        
        //Информация об образовании
     


        [Display(Name = "Название учебного заведения")]
        public ICollection<string> EducationCollegeName { get; set; }


        [Display(Name = "Специальность")]
        public ICollection<string> EducationSpeciality { get; set; }


        [Display(Name = "Номер диплома")]
        public ICollection<int> EducationDipNumber { get; set; }


        [Display(Name = "Серия диплома")]
        public ICollection<string> EducationSeriesOfDiplom { get; set; }
      
        //Данные о трудовой книжке
        [Required]
        [Display(Name = "Номер трудовой книжки")]
        public int WorkBookNumber { get; set; }

        [Display(Name = "Дата регистрации книжки")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime WorkBookDataRegistration { get; set; }

        //Данные о предыдущих местах работы
        [Display(Name = "должность")]
        public ICollection<string>  WorkPlaPosition { get; set; }

        [Display(Name = "Дата начала роботы")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public ICollection<DateTime> WorkPlaceBegin { get; set; }

        [Display(Name = "Дата окончания работы роботы")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public ICollection<DateTime> WorkPlaceFinish { get; set; }

        [Display(Name = "Причина увольнения")]
        public ICollection<string> WorkPlaceReasonForLeaving { get; set; }

        [Display(Name = "Адресс и название места работы")]
        public ICollection<string> WorkPlaceCompanyName { get; set; }
        // данные о паспорте
        [MaxLength(50, ErrorMessage = "Длина поля превышенна")]
        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }

        [Display(Name = "Номер паспорта")]
        public int PassportNumber { get; set; }
        [MaxLength(50, ErrorMessage = "Длина поля превышенна")]
        [Display(Name = "Кем выдан")]
        public string PassportGave { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime PassportDateOfIssue { get; set; }
        //Коллекции
        public ICollection<WorkPlace> WP { get; set; }
        public ICollection<Passport> Passports { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<WorkBook> WorkBooks { get; set; }



    }
}