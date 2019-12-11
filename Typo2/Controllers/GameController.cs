using System;
using System.Collections.Generic;
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
            if (Request.Cookies["LicenseInfo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}