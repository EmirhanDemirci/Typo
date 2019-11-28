using System;
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
            _accountServices.Register(account.MailUser, account.Password, account.FirstName, account.LastName, account.BirthDate);

            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            //account.password = null;
            try {_accountServices.Login(account.MailUser, account.Password);}
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }
            if (account.MailUser != null || account.Password != null || account.UserId != 0) 
            {
                HttpCookie cookie = new HttpCookie("UserInfo");
                string userJson = JsonConvert.SerializeObject(account);
                cookie.Value = userJson;
                //cookie["Password"] = account.password;
                cookie.Expires.AddDays(1);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LogIn", "Account");

        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                var c = new HttpCookie("UserInfo");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}