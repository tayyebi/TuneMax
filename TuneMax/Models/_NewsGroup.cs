using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class NewsGroup
    {
        [Display(Name="سریال")]
        public System.Guid id { get; set; }

        [Display(Name="گروه")]
        [Required(ErrorMessage="*")]
        public string Name { get; set; }
    }
}