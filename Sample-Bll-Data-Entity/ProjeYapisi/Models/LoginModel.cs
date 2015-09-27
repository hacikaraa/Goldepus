using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeYapisi.Models
{
    public class LoginModel
    {
        private string sPassword;
        private string sEmail;

        [StringLength(150, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır!")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} alanı gereklidir!")]
        [System.Web.Mvc.Remote("ValidateEmail", "Account")]
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }

        [StringLength(50, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır!", MinimumLength = 6)]
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }

    }
}