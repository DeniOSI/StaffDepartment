//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffDepartment
{
    using System;
    using System.Collections.Generic;
    
    public partial class Educations
    {
        public int EId { get; set; }
        public string CollegeName { get; set; }
        public string Speciality { get; set; }
        public int DipNumber { get; set; }
        public string SeriesOfDiplom { get; set; }
        public int WId { get; set; }
    
        public virtual Workers Workers { get; set; }
    }
}
