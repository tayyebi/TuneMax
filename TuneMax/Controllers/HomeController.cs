using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using TuneMax.Models;

namespace TuneMax.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseModelContainer db = new DatabaseModelContainer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            var sliderset = db.SliderSet.OrderByDescending(m => m.Id).Take(3);
            return PartialView(sliderset.ToList());
        }

        public ActionResult Buy(Guid id)
        {
            if (Session["username"] != null && id != null)
            {
                var usersbasket = db.UsersBaskets.Find(id);
                if (usersbasket != null)
                {
                    ViewBag._ProductTitle = usersbasket.Product.Title.ToString();
                    ViewBag._ProductID = usersbasket.Product.Id.ToString();
                    ViewBag._ProductPrice = usersbasket.Product.PriceInDollar.ToString();
                    ViewBag._ProductImage = usersbasket.Product.Image.ToString();
                    return View(usersbasket);
                }
                else return HttpNotFound();
            }
            else
                return RedirectToAction("Basket");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(ShopList shoplist, Guid id)
        {
            if (Session["username"] != null && id != null)
            {
                var usersbasket = db.UsersBaskets.Find(id);
                shoplist.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();
                shoplist.UsersUsername = usersbasket.UsersUsername;
                shoplist.ProductId = usersbasket.ProductId;
                if (ModelState.IsValid)
                {
                    shoplist.Id = usersbasket.Id;
                    db.ShopLists.Add(shoplist);
                    db.UsersBaskets.Remove(usersbasket);
                    db.SaveChanges();
                    return RedirectToAction("Basket");
                }
                return View(shoplist);
            }
            else
                return RedirectToAction("Basket");
        }

        [ChildActionOnly]
        public PartialViewResult TopNews()
        {
            return PartialView(db.NewsSet.OrderByDescending(m => m.Date).Take(10));
        }
        
        [ChildActionOnly]
        public PartialViewResult TopProducts()
        {
            return PartialView(db.ProductSet.OrderByDescending(m => m.Date).Take(10));
        }

        public ActionResult NewsShow(Guid id)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult ProductShow(Guid id)
        {
            Product product = db.ProductSet.Find(id);
            if (product == null)
                return HttpNotFound();
            else
                return View(product);
        }

        public ActionResult NewsGroup(Guid id)
        {
            var newsset = db.NewsSet.Where(m => m.NewsGroup.id == id).OrderByDescending(m => m.Date);
            return View(newsset.ToList());
        }

        public ActionResult ProductGroup(Guid id)
        {
            var productset = db.ProductSet.Where(m => m.ProductGroup.Id == id).OrderByDescending(m => m.Date);
            return View(productset.ToList());
        }

        public PartialViewResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin ul)
        {
            if (ModelState.IsValid)
            {
                var _user = db.UsersSet.Find(ul.Username);
                if (_user != null)
                {
                    if (_user.Password.ToString() == ul.Password.ToString())
                    {
                        ViewBag.Message = "شما با موفقیت به سیستم وارد شدید!";
                        Session["username"] = ul.Username;
                        Session["fullname"] = _user.FirstName.ToString() + " " + _user.LastName.ToString();
                    }
                    else
                        ViewBag.Message = "نام کاربری یا کلمه عبور معتبر نمی باشد!";
                }
                else if (_user == null)
                    ViewBag.Message = "نام کاربری یا کلمه عبور معتبر نمی باشد!";
            } 
            return PartialView();
        }

        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                if (db.UsersSet.Find(user.Username) == null)
                {
                    if (user.Password == user.ConfirmPassword)
                    {
                        db.UsersSet.Add(user);
                        db.SaveChanges();
                        ViewBag.Message = "کاربر " + user.Username + " به سیستم معرفی شد.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.Message = "کلمه عبور با تکرار آن هماهنگ نیست!";
                }
                else
                    ViewBag.Message = "این نام کاربری قبلا انتخاب شده است";
            }
            else
            {
                ViewBag.Message = "معتبر نیست!";
            }
            return View();
        }

        public PartialViewResult UserStatus()
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Basket()
        {
            if (Session["username"] != null)
            {
                return View(db.UsersBaskets.OrderByDescending(m => m.Id).ToList());
            }
            else
            {
                ViewBag.Message = "برای دسترسی به محتویات این صفحه باید ابتدا لاگین کنید.";
                var Basket = db.UsersBaskets.Take(0).ToList();
                return View(Basket);
            }
        }

        public ActionResult Add(Guid id)
        {
            if (Session["username"] != null && id != null)
            {
                var product = db.ProductSet.Find(id);
                ViewBag._ProductTitle = product.Title.ToString();
                ViewBag._ProductPrice = product.PriceInDollar.ToString();
                ViewBag._ProductImage = product.Image.ToString();
                return View();
            }
            else
                return RedirectToAction("Basket");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UsersBasket usersbasket, Guid id)
        {
            if (Session["username"] != null && id != null)
            {

                usersbasket.UsersUsername = Session["username"].ToString();
                usersbasket.ProductId = id;
                if (ModelState.IsValid)
                {
                    usersbasket.Id = Guid.NewGuid();
                    db.UsersBaskets.Add(usersbasket);
                    db.SaveChanges();
                    return RedirectToAction("Basket");
                }
                return View(usersbasket);
            }
            else
                return RedirectToAction("Basket");
        }

        public ActionResult Delete(Guid id)
        {
            if (id != null && Session["username"] != null)
            {
                UsersBasket usersbasket = db.UsersBaskets.Find(id);
                if (usersbasket == null)
                    return HttpNotFound();

                ViewBag._ProductTitle = usersbasket.Product.Title.ToString();
                ViewBag._ProductPrice = usersbasket.Product.PriceInDollar.ToString();
                ViewBag._ProductImage = usersbasket.Product.Image.ToString();
                return View(usersbasket);
            }
            else return RedirectToAction("Basket");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UsersBasket usersbasket = db.UsersBaskets.Find(id);
            db.UsersBaskets.Remove(usersbasket);
            db.SaveChanges();
            return RedirectToAction("Basket");
        }

        public ActionResult UserProfile()
        {
            if (Session["username"] == null)
                return HttpNotFound();
            Users users = db.UsersSet.Find(Session["username"]);
            if (users == null)
                return HttpNotFound();
            if (Request.IsAjaxRequest())
                return PartialView(users);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile(Users users)
        {
            if (Session["username"] == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                Session["fullname"] = users.FirstName + " " + users.LastName;
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
                return PartialView(users);
            return View(users);
        }

        public ActionResult ChangePassword()
        {
            if (Session["username"] == null)
                return RedirectToAction("UserProfile");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }
        public Boolean ChangePaswordForUser(string Username, string NewPassword, string OldPassword)
        {
            Boolean output = false;
            Users _user = db.UsersSet.Find(Username);
            if (_user.Password == OldPassword)
            {
                _user.Password = NewPassword;
                db.SaveChanges();
                output = true;
            }
            return output;
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(String old_password, String password, String confirm_password)
        {
            try
            {
                if (password == confirm_password)
                {
                    if ((ChangePaswordForUser(Session["username"].ToString(), password, old_password) == true))
                    { return RedirectToAction("Logout", "Home"); }

                    ViewBag.Message = "تکرار کلمه عبور صحیح نیست و یا اینکه تمامی فیلد ها کامل نشده اند.";
                    if (Request.IsAjaxRequest())
                        return PartialView();
                    return View();
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

        //
        // GET: /Home/Comment

        public ActionResult Comment(Guid id)
        {
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Title");
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        //
        // POST: /Home/Comment

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(Comment comment, Guid id)
        {
            if (id == null)
                return HttpNotFound();

            if (Session["username"] != null)
            {
                comment.Username = Session["username"].ToString();
                comment.Email = "[کاربر]";
            }
            else
            {
                comment.Username = "[کاربر مهمان]";
            }

            comment.ProductId = id;
            comment.Date = DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString();

            if (ModelState.IsValid)
            {
                comment.Id = Guid.NewGuid();
                db.CommentSet.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();

        }

        public ActionResult Comments(Guid id)
        {
            if (id == null)
                return HttpNotFound();
            var commentset = db.CommentSet.Where(m => m.ProductId == id).OrderByDescending(m => m.Date).Take(50);
            if (Request.IsAjaxRequest())
                return PartialView(commentset.ToList());
            return View(commentset.ToList());
        }

        public ActionResult AppError()
        {
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}