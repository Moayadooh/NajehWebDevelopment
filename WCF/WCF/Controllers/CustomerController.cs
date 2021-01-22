using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.ServiceReferenceCustomer;

namespace WCF.Controllers
{
    // Access WCF Service Web

    public class CustomerController : Controller
    {
        ServiceClient srv = new ServiceClient();

        public ActionResult Index()
        {
            return View(srv.GetAllCustomer());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                srv.AddCustomer(customer);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}