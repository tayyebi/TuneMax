using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Product/Archive
        public ActionResult Archive()
        {
            var uploadset = db.UploadSet.OrderByDescending(m => m.Date);
            return View(uploadset.ToList());
        }

        //
        // GET: /Upload/

        public ActionResult Index(Guid? id=null)
        {
            if (id == null)
            {
                var uploadset = db.UploadSet.OrderByDescending(m => m.Date).Take(10);
                return View(db.UploadSet.ToList());
            }
            else
            {
                return View(db.UploadSet.Where(m => m.UploadGroupId == id).OrderByDescending(m => m.Date).Take(10));
            }
        }

        //
        // GET: /Upload/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Upload upload = db.UploadSet.Find(id);
            if (upload == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(upload);
            return View(upload);
        }

        //
        // GET: /Upload/Create

        public ActionResult Create()
        {
            ViewBag.UploadGroupId = new SelectList(db.UploadGroupSet, "Id", "Name");
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /Upload/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Upload upload,HttpPostedFileBase FileUploader)
        {
            upload.AccountUsername = User.Identity.Name;
            using (MemoryStream ms = new MemoryStream())
            {
                FileUploader.InputStream.CopyTo(ms);
                upload.Bytes=ms.GetBuffer();
            }
            upload.ContentLength = FileUploader.ContentLength;
            upload.ContentType = FileUploader.ContentType;
            upload.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                upload.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();
                upload.Id = Guid.NewGuid();
                db.UploadSet.Add(upload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UploadGroupId = new SelectList(db.UploadGroupSet, "Id", "Name", upload.UploadGroupId);
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", upload.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(upload);
            return View(upload);
        }

        //
        // GET: /Upload/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Upload upload = db.UploadSet.Find(id);
            if (upload == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(upload);
            return View(upload);
        }

        //
        // POST: /Upload/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Upload upload = db.UploadSet.Find(id);
            db.UploadSet.Remove(upload);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}