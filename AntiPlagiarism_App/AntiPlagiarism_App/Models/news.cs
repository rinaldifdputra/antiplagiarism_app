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
    
    public partial class news
    {
        public long newsID { get; set; }
        public string newsTitle { get; set; }
        public string newsInfo { get; set; }
        public Nullable<System.DateTime> last_update { get; set; }
        public Nullable<short> active { get; set; }
        public Nullable<long> ID_user { get; set; }
    
        public virtual user user { get; set; }
    }
}
