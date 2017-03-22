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
    public class SliderController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Slider/

        public ActionResult Index()
        {
            var sliderset = db.SliderSet.OrderByDescending(m => m.Id);
            return View(sliderset.ToList());
        }

        //
        // GET: /Slider/Details/5

        public ActionResult Details(int id = 0)
        {
            Slider slider = db.SliderSet.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(slider);
            return View(slider);
        }

        //
        // GET: /Slider/Create

        public ActionResult Create()
        {
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /Slider/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider)
        {
            slider.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.SliderSet.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", slider.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(slider);
            return View(slider);
        }

        //
        // GET: /Slider/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Slider slider = db.SliderSet.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", slider.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(slider);
            return View(slider);
        }

        //
        // POST: /Slider/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider)
        {
            slider.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", slider.AccountUsername);
            if (Request.IsAjaxRequest())
                return PartialView(slider);
            return View(slider);
        }

        //
        // GET: /Slider/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Slider slider = db.SliderSet.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(slider);
            return View(slider);
        }

        //
        // POST: /Slider/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.SliderSet.Find(id);
            db.SliderSet.Remove(slider);
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