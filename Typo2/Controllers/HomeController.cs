using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Typo.Logic.Services;
using Typo.Model.Models;

namespace Typo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminService _adminServices;
        private readonly AccountService _accountServices;
     
        public HomeController()
        {
            //Getting the accountservices
            _accountServices = new AccountService();
            //Getting the adminservices
            _adminServices = new AdminService();
        }

        [HttpPost]
        public ActionResult Index(Account account)
        {
            //Logging the user in
            Account Account;
            try { Account = _accountServices.Login(account.MailUser, account.Password); }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }
            //Making the cookies of that particular account
            if (Account != null)
            {
                HttpCookie cookie = new HttpCookie("UserInfo");
                string userJson = JsonConvert.SerializeObject(Account);
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
            return View();
        }

        public ActionResult purchase()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Games()
        {
            return View();
        }
        public ActionResult Admin()
        {
            //Getting access to the admin page if the admin INT == 1
            if (Request.Cookies["UserInfo"] != null)
            {
                Account user;
                user = JsonConvert.DeserializeObject<Account>(Request.Cookies["UserInfo"].Value);
                if (user.IsAdmin == 1)
                {
                    List<Account> listAccounts;
                    listAccounts = _adminServices.GetAllAccounts();
                    return View(listAccounts);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Admin(Account account)
        {
            //Getting access to the DeleteAccount function inside adminServices
            try
            {
                _adminServices.DeleteAccount(account.UserId);

                return RedirectToAction("Admin", "Home");

            }
            catch (Exception e)
            {
                return Json("error");
            }
           
        }
        public ActionResult Docent()
        {
            //Loggin the teacher in
            Account user;
            if (Request.Cookies["UserInfo"] != null)
            {
                user = JsonConvert.DeserializeObject<Account>(Request.Cookies["UserInfo"].Value);
                if (user.IsDocent == 1)
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}