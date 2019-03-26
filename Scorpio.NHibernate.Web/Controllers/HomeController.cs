using Scorpio.NHibernate.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scorpio.NHibernate.Web.Controllers
{
    public class HomeController : Controller
    {
        CustomersBusiness customersBusiness = new CustomersBusiness();
        public ActionResult Index()
        {
            var list = customersBusiness.GetCustomerList(x => true);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}