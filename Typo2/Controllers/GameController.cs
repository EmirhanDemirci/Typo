using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Typo2.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult TypeRacer()
        {
            return View();
        }
    }
}