//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AntiPlagiarism_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class classroom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public classroom()
        {
            this.classroom_detail = new HashSet<classroom_detail>();
            this.classroom_upload = new HashSet<classroom_upload>();
        }
    
        public long classID { get; set; }
        public string classNm { get; set; }
        public string info { get; set; }
        public Nullable<System.DateTime> startDt { get; set; }
        public Nullable<System.DateTime> endDt { get; set; }
        public Nullable<short> active { get; set; }
        public Nullable<short> isPrivate { get; set; }
        public Nullable<System.DateTime> last_update { get; set; }
        public Nullable<long> ID_user { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classroom_detail> classroom_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classroom_upload> classroom_upload { get; set; }
        public virtual user user { get; set; }
    }
}