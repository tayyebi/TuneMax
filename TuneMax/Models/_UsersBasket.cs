using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class UsersBasket
    {
        [Display(Name = "سریال")]
        public System.Guid Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string UsersUsername { get; set; }

        [Display(Name = "محصول")]
        public System.Guid ProductId { get; set; }

        [Display(Name="سریال خرید")]
        public int ShopId { get; set; }
    }
}