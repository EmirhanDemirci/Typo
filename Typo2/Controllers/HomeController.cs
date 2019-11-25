using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typo.Model.Models;

namespace Typo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HttpCookie cookie = Request.Cookies["UserInfo"];
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