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
    
    public partial class WorkBooks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkBooks()
        {
            this.WorkPlaces = new HashSet<WorkPlaces>();
        }
    
        public int WorkBookID { get; set; }
        public System.DateTime BeginDate { get; set; }
        public int RecordID { get; set; }
    
        public virtual Workers Workers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkPlaces> WorkPlaces { get; set; }
    }
}
