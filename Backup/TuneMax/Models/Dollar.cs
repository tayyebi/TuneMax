using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public class Dollar
    {
        public Dollar()
        {
            this.ID = 0;
            this.date = null;
            this.price = null;
        }

        public Dollar(int id, string date, string price)
        {
            this.ID = id;
            this.date = date;
            this.price = price;
        }

        public Dollar(int id)
        {
            this.ID = id;
        }

        [Display(Name="سریال")]
        public int ID { get; set; }

        [Required(ErrorMessage="*")]
        [Display(Name="قیمت")]
        public string price { get; set; }

        [Display(Name="تاریخ")]
        public string date { get; set; }
    }
}