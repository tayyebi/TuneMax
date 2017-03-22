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
    public class ProductGroupController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /ProductGroup/

        public ActionResult Index()
        {
            var productgroupset = db.ProductGroupSet;
            return View(productgroupset.ToList());
        }

        //
        // GET: /ProductGroup/Details/5

        public ActionResult Details(Guid? id = null)
        {
            ProductGroup productgroup = db.ProductGroupSet.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(productgroup);
            return View(productgroup);
        }

        //
        // GET: /ProductGroup/Create

        public ActionResult Create()
        {
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /ProductGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductGroup productgroup)
        {
            productgroup.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                productgroup.Id = Guid.NewGuid();
                db.ProductGroupSet.Add(productgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", productgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(productgroup);
            return View(productgroup);
        }

        //
        // GET: /ProductGroup/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            ProductGroup productgroup = db.ProductGroupSet.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", productgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(productgroup);
            return View(productgroup);
        }

        //
        // POST: /ProductGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductGroup productgroup)
        {
            productgroup.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(productgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", productgroup.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(productgroup);
            return View(productgroup);
        }

        //
        // GET: /ProductGroup/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            ProductGroup productgroup = db.ProductGroupSet.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(productgroup);
            return View(productgroup);
        }

        //
        // POST: /ProductGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductGroup productgroup = db.ProductGroupSet.Find(id);
            db.ProductGroupSet.Remove(productgroup);
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