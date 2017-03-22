using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class Slider
    {
        [Display(Name = "سریال")]
        public Int16 Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "آدرس تصویر")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "آدرس مقصد")]
        public string Href { get; set; }

        [Display(Name = "توضیح")]
        public string Description { get; set; }

        [Display(Name = "نام کاربری")]
        public string AccountUsername { get; set; }
    }
}