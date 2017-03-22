using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class News
    {
        public System.Guid Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "*")]
        public string Title { get; set; }

        [Display(Name = "چکیده")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "*")]
        public string Abstract { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        [Display(Name="گروه")]
        public System.Guid NewsGroup_id { get; set; }

        [Display(Name = "نام کاربری")]
        public string AccountUsername { get; set; }

    }
}