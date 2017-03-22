using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    [Authorize]
    public class UploadGroupController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /UploadGroup/

        public ActionResult Index()
        {
            var uploadgroupset = db.UploadGroupSet;
            return View(uploadgroupset.ToList());
        }

        //
        // GET: /UploadGroup/Details/5

        public ActionResult Details(Guid? id = null)
        {
            UploadGroup uploadgroup = db.UploadGroupSet.Find(id);
            if (uploadgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(uploadgroup);
            return View(uploadgroup);
        }

        //
        // GET: /UploadGroup/Create

        public ActionResult Create()
        {
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /UploadGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UploadGroup uploadgroup)
        {
            uploadgroup.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                uploadgroup.Id = Guid.NewGuid();
                db.UploadGroupSet.Add(uploadgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", uploadgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(uploadgroup);
            return View(uploadgroup);
        }

        //
        // GET: /UploadGroup/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            UploadGroup uploadgroup = db.UploadGroupSet.Find(id);
            if (uploadgroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", uploadgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(uploadgroup);
            return View(uploadgroup);
        }

        //
        // POST: /UploadGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UploadGroup uploadgroup)
        {
            uploadgroup.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(uploadgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", uploadgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(uploadgroup);
            return View(uploadgroup);
        }

        //
        // GET: /UploadGroup/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            UploadGroup uploadgroup = db.UploadGroupSet.Find(id);
            if (uploadgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(uploadgroup);
            return View(uploadgroup);
        }

        //
        // POST: /UploadGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UploadGroup uploadgroup = db.UploadGroupSet.Find(id);
            db.UploadGroupSet.Remove(uploadgroup);
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