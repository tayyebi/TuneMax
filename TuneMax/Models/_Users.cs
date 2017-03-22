using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuneMax.Models
{
    public partial class Users
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است چرا که برای ورود به این نام نیاز دارید")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "وارد کردن تلفن الزامی است چرا که برای پیگیری محصولات به این شماره تماس گرفته خواهد شد")]
        public string PhoneNumber { get; set; }

        [Display(Name="آدرس و کد پستی")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage="وارد کردن آدرس الزامی است چرا که محصولات به این آدرس ارسال خواهند شد.")]
        public string Adress { get; set; }

        [Display(Name = "شغل")]
        public string Job { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="تکرار کلمه عبور با اصل آن هماهنگی ندارد.")]
        [Display(Name = "تکرار کلمه عبور")]
        public string ConfirmPassword { get; set; }
    }
}