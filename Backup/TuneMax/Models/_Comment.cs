using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class Comment
    {
        [Display(Name="سریال")]
        public System.Guid Id { get; set; }

        [Display(Name = "فرستنده")]
        public string Email { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public string Date { get; set; }

        [Display(Name = "نام کاربری فرستنده (درصورت لاگین)")]
        public string Username { get; set; }

        [Display(Name = "سریال محصول")]
        public System.Guid ProductId { get; set; }
    }
}