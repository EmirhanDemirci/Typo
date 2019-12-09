﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            Account user;
            if (Request.Cookies["UserInfo"] != null)
            { 
                user = JsonConvert.DeserializeObject<Account>(Request.Cookies["UserInfo"].Value);
                _keyServices.GenerateKey(key.LicenseKey, user.UserId);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}