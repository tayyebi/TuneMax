using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /News/

        public ActionResult Index(Guid? id = null)
        {
            if (id == null)
            {
                var newsset = db.NewsSet.OrderByDescending(m => m.Date).Take(10);
                return View(newsset.ToList());
            }
            else
            {
                var newsset = db.NewsSet.Where(m => m.NewsGroup_id == id).OrderByDescending(m => m.Date).Take(30);
                return View(newsset.ToList());
            }
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(Guid? id = null)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.NewsGroup_id = new SelectList(db.NewsGroupSet, "id", "Name");
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(News news)
        {
            news.AccountUsername = User.Identity.Name;
            news.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();
            if (ModelState.IsValid)
            {
                news.Id = Guid.NewGuid();
                db.NewsSet.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewsGroup_id = new SelectList(db.NewsGroupSet, "id", "Name", news.NewsGroup_id);
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", news.AccountUsername);
            return View(news);
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsGroup_id = new SelectList(db.NewsGroupSet, "id", "Name", news.NewsGroup_id);
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", news.AccountUsername);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            news.AccountUsername = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsGroup_id = new SelectList(db.NewsGroupSet, "id", "Name", news.NewsGroup_id);
            ViewBag.AccountUsername = new SelectList(db.AccountSet, "Username", "FirstName", news.AccountUsername);
            return View(news);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            News news = db.NewsSet.Find(id);
            db.NewsSet.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // GET: /News/Archive
        public ActionResult Archive()
        {
            var news = db.NewsSet.ToList();
            return View(news);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}