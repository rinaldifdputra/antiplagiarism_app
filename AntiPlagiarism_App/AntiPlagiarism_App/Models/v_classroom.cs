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
    
    public partial class v_classroom
    {
        public long classID { get; set; }
        public string classNm { get; set; }
        public string info { get; set; }
        public string startDt { get; set; }
        public string endDt { get; set; }
        public string last_update { get; set; }
        public Nullable<short> active { get; set; }
        public Nullable<short> isPrivate { get; set; }
        public string username { get; set; }
    }
}