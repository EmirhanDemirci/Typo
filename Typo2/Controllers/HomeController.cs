﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Typo.Logic.Services;
using Typo.Model.Models;

namespace Typo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService _accountServices;

        public HomeController()
        {
            _accountServices = new AccountService();
        }
        [HttpPost]
        public ActionResult Index(Account account)
        {
            //account.password = null;
            Account newAccount;
            try { newAccount = _accountServices.Login(account.MailUser, account.Password); }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }
            if (newAccount != null)
            {
                HttpCookie cookie = new HttpCookie("UserInfo");
                string userJson = JsonConvert.SerializeObject(newAccount);
                cookie.Value = userJson;
                //cookie["Password"] = account.password;
                cookie.Expires.AddDays(1);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        public ActionResult Index()
        {
            //HttpCookie cookie = Request.Cookies["UserInfo"];
            return View();
        }

        public ActionResult purchase()
        {
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
        public ActionResult Admin()
        {
            Account user;
            if (Request.Cookies["UserInfo"] != null)
            {
                user = JsonConvert.DeserializeObject<Account>(Request.Cookies["UserInfo"].Value);
                if (user.IsAdmin == 1)
                {
                    return View();
                }
            }


            return RedirectToAction("Index", "Home");
        }
    }
}