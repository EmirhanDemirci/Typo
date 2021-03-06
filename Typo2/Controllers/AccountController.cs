﻿using System;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Typo.Logic.Services;
using Typo.Model.Models;

namespace Typo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountServices;


        public AccountController()
        {
            //Get the accountservices
            _accountServices = new AccountService();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account account)
        {
            //Using the registration function inside accountServices
            _accountServices.Register(account.MailUser, account.Password, account.FirstName, account.LastName, account.BirthDate, account.IsAdmin, account.IsDocent);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            //deleting the cookies
            if (Request.Cookies["UserInfo"] != null)
            {
                var c = new HttpCookie("UserInfo");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}