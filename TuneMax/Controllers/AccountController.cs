using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    public class AccountController : Controller
    {
        DatabaseModelContainer db = new DatabaseModelContainer();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (Membership.GetAllUsers().Count == 0)
                Membership.CreateUser("admin", "admin");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLogin al)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(al.Username, al.Password))
                {
                    FormsAuthentication.SetAuthCookie(al.Username, al.KeepMe);
                    return RedirectToAction("Index", "Account");
                }
                ViewBag.LoginError = "نام کاربری یا کلمه عبور معتبر نمی باشد";
            }

            return View();
        }

        [ChildActionOnly]
        [Authorize]
        public PartialViewResult Menu()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        [ChildActionOnly]
        [Authorize]
        public PartialViewResult Tools()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            Account account = db.AccountSet.Find(User.Identity.Name);
            if (account == null)
            {
                Account _account = new Account();
                _account.Username = User.Identity.Name.ToString();
                _account.FirstName = "[name]";
                _account.LastName = "[lastname]";
                _account.Email = "no-reply@" + HttpContext.Request.Url.Host.ToString().ToUpper();
                db.AccountSet.Add(_account);
                db.SaveChanges();
            }
            if (Request.IsAjaxRequest())
                return PartialView(account);
            return View(account);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UserProfile(Account account)
        {
            account.Username = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Account");
            }
            if (Request.IsAjaxRequest())
                return PartialView(account);
            return View(account);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(String old_password,String password,String confirm_password)
        {
            try
            {
                if (password == confirm_password)
                {
                    MembershipUser user = Membership.GetUser(User.Identity.Name);
                    user.ChangePassword(old_password, password);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "تکرار کلمه عبور صحیح نیست و یا اینکه تمامی فیلد ها کامل نشده اند.";
                    if (Request.IsAjaxRequest())
                        return PartialView();
                    return View();
                }
            }
            catch
            {
                ViewBag.Message = "تکرار کلمه عبور صحیح نیست و یا اینکه تمامی فیلد ها کامل نشده اند.";
                if (Request.IsAjaxRequest())
                    return PartialView();
                return View();
            }
        }
    }
}