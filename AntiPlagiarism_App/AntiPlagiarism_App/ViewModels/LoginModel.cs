using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AntiPlagiarism_App.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username tidak boleh kosong !!!")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password tidak boleh kosong !!!")]
        public string password { get; set; }
    }
}