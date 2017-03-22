using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public class AccountLogin
    {
        [Display(Name="نام کاربری")]
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }
        [Display(Name="کلمه عبور")]
        [Required(ErrorMessage="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool KeepMe { get; set; }
    }
}