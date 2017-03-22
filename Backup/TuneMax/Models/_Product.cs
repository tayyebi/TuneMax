using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class Product
    {
        [Display(Name="سریال")]
        public System.Guid Id { get; set; }
        
        [Display(Name="عنوان")]
        [Required(ErrorMessage="*")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage="*")]
        public string Description { get; set; }
        
        [Display(Name="قیمت به دلار")]
        public string PriceInDollar { get; set; }
        
        [Display(Name="تصویر")]
        [Required(ErrorMessage="ارسال تصویر برای محصولات الزامی است!")]
        public string Image { get; set; }
        
        [Display(Name="نام کاربری")]
        public string AccountUsername { get; set; }

        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        [Display(Name="سریال گروه")]
        public System.Guid ProductGroupId { get; set; }
    }
}