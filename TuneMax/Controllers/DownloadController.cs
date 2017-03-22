using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    public class DownloadController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Download/

        public ActionResult Index(Guid id)
        {
            Upload upload = db.UploadSet.Find(id);
            return File(upload.Bytes, upload.ContentType);
        }

    }
}
