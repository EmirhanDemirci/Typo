using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typo.Logic.Services;
using Typo.Model.Models;

namespace Typo2.Controllers
{
    public class LicenseController : Controller
    {
        private readonly KeyService _keyServices;
        public LicenseController()
        {
            _keyServices = new KeyService();
        }
        // GET: License
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GenerateKey(Key key)
        {
            _keyServices.GenerateKey(key.LicenseKey);
            return RedirectToAction("Index", "Home");
        }
    }
}