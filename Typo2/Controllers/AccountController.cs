using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
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
            _accountServices.Register(account.username, account.password);

            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            StringBuilder sb = new StringBuilder();
            _accountServices.Login(account.username, account.password);
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie["Username"] = account.username;
            sb.Append("Cookie value : " + cookie.Value);
            //cookie["Password"] = account.password;
            cookie.Expires.AddDays(1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
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