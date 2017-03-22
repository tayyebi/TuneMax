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
    public class SaleController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        //
        // GET: /Print/

        public ActionResult Print()
        {
            var shoplists = db.ShopLists.OrderBy(m => m.Product.Title);
            return PartialView(shoplists.ToList());
        }

        //
        // GET: /Sale/

        public ActionResult Index()
        {
            var shoplists = db.ShopLists.OrderByDescending(m => m.Date);
            return View(shoplists.ToList());
        }

        //
        // GET: /Sale/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            ShopList shoplist = db.ShopLists.Find(id);
            if (shoplist == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
                return PartialView(shoplist);
            return View(shoplist);
        }

        //
        // POST: /Sale/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ShopList shoplist = db.ShopLists.Find(id);
            db.ShopLists.Remove(shoplist);
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