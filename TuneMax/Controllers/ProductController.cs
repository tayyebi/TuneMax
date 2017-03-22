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
    public class ProductController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Product/

        public ActionResult Index(Guid? id=null)
        {
            if (id == null)
            {
                var productset = db.ProductSet.OrderByDescending(m => m.Date).Take(10);
                return View(productset.ToList());
            }
            else
            {
                var productset = db.ProductSet.Where(m => m.ProductGroupId == id).OrderByDescending(m => m.Date).Take(30);
                return View(productset.ToList());
            }
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(product);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName");
            ViewBag.ProductGroupId = new SelectList(db.ProductGroupSet, "Id", "Name");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.AccountUsername = User.Identity.Name;
            product.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                db.ProductSet.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", product.AccountUsername);
            ViewBag.ProductGroupId = new SelectList(db.ProductGroupSet, "Id", "Name", product.ProductGroupId);
            if (Request.IsAjaxRequest())
                return PartialView(product);
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", product.AccountUsername);
            ViewBag.ProductGroupId = new SelectList(db.ProductGroupSet, "Id", "Name", product.ProductGroupId);
            if (Request.IsAjaxRequest())
                return PartialView(product);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            product.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();
            product.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", product.AccountUsername);
            ViewBag.ProductGroupId = new SelectList(db.ProductGroupSet, "Id", "Name", product.ProductGroupId);
            if (Request.IsAjaxRequest())
                return PartialView(product);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(product);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.ProductSet.Find(id);
            db.ProductSet.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Archive
        public ActionResult Archive()
        {
            var productset = db.ProductSet.OrderByDescending(m => m.Date);
            return View(productset.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}