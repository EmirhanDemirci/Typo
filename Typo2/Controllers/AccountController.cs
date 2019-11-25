using System.Web.Mvc;
using System.Web.Routing;
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
            _accountServices.Login(account.username, account.password);
            return RedirectToAction("Index", "Home", new RouteValueDictionary(account));
        }

        public ActionResult LogOut()
        {
            if (Session["userId"] != null)
            { 
               Session["userId"] = null;
            }

            return RedirectToAction("Login", "Account");
        }
    }
}