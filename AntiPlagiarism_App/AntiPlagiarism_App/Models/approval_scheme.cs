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
    
    public partial class approval_scheme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public approval_scheme()
        {
            this.approval_scheme_detail = new HashSet<approval_scheme_detail>();
        }
    
        public long schemeID { get; set; }
        public string apvType { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<long> ID_user { get; set; }
        public Nullable<short> is_level { get; set; }
        public Nullable<short> max_level { get; set; }
        public string sp_name { get; set; }
    
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<approval_scheme_detail> approval_scheme_detail { get; set; }
    }
}
