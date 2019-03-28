using Scorpio.Mvc.Common;
using Scorpio.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scorpio.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Shippers shippers = new Shippers();
            shippers.CompanyName = "aaaaa";
            shippers.Phone = "aaaaa";
            Repository repository = new Repository();
            repository.Add(shippers);
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