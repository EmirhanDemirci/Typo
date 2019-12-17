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
            if (Request.Cookies["LicenseInfo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult GetExcelFile()
        {
            var fileDownloadName = "GuessTheNumber.exe";
            var contentType = "application/zip";

            var fileStream = new MemoryStream();
            fileStream.Position = 0;


            return File(fileStream, contentType, fileDownloadName);
        }
    }
}