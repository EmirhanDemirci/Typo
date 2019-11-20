using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Typo.Controllers
{
    public class GameController : Controller
    {
        public IActionResult TypeRacer()
        {
            return View();
        }
    }
}