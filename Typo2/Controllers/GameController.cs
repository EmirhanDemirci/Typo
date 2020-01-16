using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Typo.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult TypeRacer()
        {
            //Checks if the user has a license
            if (Request.Cookies["LicenseInfo"] != null)
            {
                return View();
            }
            else
            {
                //Otherwise return the home page
                return RedirectToAction("Index", "Home");
            }
        }
    }
}