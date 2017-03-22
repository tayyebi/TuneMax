using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class UploadGroup
    {
        [Display(Name="سریال")]
        public System.Guid Id { get; set; }

        [Required(ErrorMessage="*")]
        [Display(Name = "گروه آپلود")]
        public string Name { get; set; }

        [Display(Name = "نام کاربری")]
        public string AccountUsername { get; set; }
    }
}