using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public partial class Upload
    {
        [Display(Name="سریال")]
        public System.Guid Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "نام فایل")]
        public string FileName { get; set; }

        [Display(Name = "نوع")]
        public string ContentType { get; set; }

        [Display(Name = "حجم")]
        public long ContentLength { get; set; }

        [Display(Name="تاریخ")]
        public string Date { get; set; }

        public byte[] Bytes { get; set; }

        [Display(Name = "سریال گروه")]
        public System.Guid UploadGroupId { get; set; }

        [Display(Name = "نام کاربری")]
        public string AccountUsername { get; set; }

        [Display(Name = "لینک دانلود")]
        public string DownloadLink
        {
            get
            {
                string WebsiteUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host.ToString().ToUpper() + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/";
                return WebsiteUrl + "Download/Index/" + Id;
            }
        }
    }
}