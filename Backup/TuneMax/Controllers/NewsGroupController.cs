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
    public class NewsGroupController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /NewsGroup/

        public ActionResult Index()
        {
            return View(db.NewsGroupSet.ToList());
        }

        //
        // GET: /NewsGroup/Details/5

        public ActionResult Details(Guid? id = null)
        {
            NewsGroup newsgroup = db.NewsGroupSet.Find(id);
            if (newsgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(newsgroup);
            return View(newsgroup);
        }

        //
        // GET: /NewsGroup/Create

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /NewsGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsGroup newsgroup)
        {
            if (ModelState.IsValid)
            {
                newsgroup.id = Guid.NewGuid();
                db.NewsGroupSet.Add(newsgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
                return PartialView(newsgroup);
            return View(newsgroup);
        }

        //
        // GET: /NewsGroup/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            NewsGroup newsgroup = db.NewsGroupSet.Find(id);
            if (newsgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(newsgroup);
            return View(newsgroup);
        }

        //
        // POST: /NewsGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsGroup newsgroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
                return PartialView(newsgroup);
            return View(newsgroup);
        }

        //
        // GET: /NewsGroup/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            NewsGroup newsgroup = db.NewsGroupSet.Find(id);
            if (newsgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(newsgroup);
            return View(newsgroup);
        }

        //
        // POST: /NewsGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NewsGroup newsgroup = db.NewsGroupSet.Find(id);
            db.NewsGroupSet.Remove(newsgroup);
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