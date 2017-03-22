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
    public class UsersController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            var users=db.UsersSet;
            int i = users.Count();
            ViewBag.Count = i.ToString();
            return View(db.UsersSet.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(string id)
        {
            Users users = db.UsersSet.Find(id);
            if (users == null)
                return HttpNotFound();

            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}