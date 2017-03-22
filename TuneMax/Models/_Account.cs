using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class Account
    {
        [Display(Name="نام کاربری")]
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage="*")]
        public string FirstName { get; set; }
        
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Display(Name="نام")]
        public string Fullname
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}