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
    
    public partial class classroom_detail
    {
        public long detailID { get; set; }
        public Nullable<long> classID { get; set; }
        public Nullable<long> ID_user { get; set; }
        public Nullable<long> roleID { get; set; }
        public Nullable<System.DateTime> joinDt { get; set; }
        public Nullable<short> active { get; set; }
    
        public virtual classroom classroom { get; set; }
        public virtual role role { get; set; }
    }
}