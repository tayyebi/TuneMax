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
    public class CommentController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            var commentset = db.CommentSet.OrderByDescending(m => m.Date).Take(20);
            return View(commentset.ToList());
        }

        //
        //GET: /Comment/Archive

        public ActionResult Archive()
        {
            var commentset = db.CommentSet.OrderByDescending(m => m.Date);
            return View(commentset.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(comment);
            return View(comment);
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Title", comment.ProductId);
            if (Request.IsAjaxRequest())
                return PartialView(comment);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Title", comment.ProductId);
            if (Request.IsAjaxRequest())
                return PartialView(comment);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(comment);
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Comment comment = db.CommentSet.Find(id);
            db.CommentSet.Remove(comment);
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