using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    [Authorize]
    public class DollarController : Controller
    {
        DollarRepository _DollarRepository = new DollarRepository();

        //
        // GET: /Dollar/

        public ActionResult Index()
        {
            var _Dollars = _DollarRepository.GetDollars().OrderByDescending(m => m.ID).Take(10).ToList();
            return View(_Dollars);
        }
        
        //
        // GET: /Create/

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dollar dollar)
        {
            if (ModelState.IsValid)
            {
                DollarRepository _dollar = new DollarRepository();
                _dollar.InsertDollar(dollar);
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
                return PartialView(dollar);
            return View(dollar);
        }

        public ActionResult Delete()
        {
            //if (ModelState.IsValid)
            {
                DollarRepository _dollar = new DollarRepository();
                _dollar.DeleteAllDollars();
            }
            return RedirectToAction("Index");
        }

    }
}
