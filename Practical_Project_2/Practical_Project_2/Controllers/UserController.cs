using Practical_Project_2.Models;
using Practical_Project_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_Project_2.Controllers
{
    public class UserController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["role"] == null || (string)Session["role"] != "User")
                Response.Redirect("~/Home/Login");
        }

        private ShoppingDB db = new ShoppingDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PurchasesHistory()
        {
            string UserID = ((User)Session["profile"]).ID.ToString();
            return View(db.UserPurchases.Where(x => x.UserID.ToString() == UserID));
            //return View((object)UserID);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Purchase(List<UserPurchaseData> list)
        {
            if (ModelState.IsValid)
            {
                UserPurchase userPurchase = new UserPurchase
                {
                    UserID = ((User)Session["profile"]).ID,
                    NumOfItems = list[0].TotalCount,
                    TotalPrice = list[0].TotalCart,
                    Date = DateTime.Now
                };
                db.UserPurchases.Add(userPurchase);
                db.SaveChanges();
                return Json("Payment Successful");
            }
            return Json("Something went wrong");
        }

        public ActionResult PaymentSuccess()
        {
            return View();
        }
    }
}