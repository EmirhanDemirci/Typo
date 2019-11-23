using System.Web.Mvc;
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

        //[HttpPost]
        //public IActionResult Register(Account accounts)
        //{
            //var query = "INSERT INTO Account(username, password) VALUES('{0}', '{1}')";
            //var queryFull = string.Format(query, accounts.username, accounts.password);
            //var sc = new SqlConnection(_connectionString);
            //sc.Open();
            //using (SqlCommand cmd = new SqlCommand(queryFull, sc))
            //{
            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        sc.Close();
            //    }
            //    catch
            //    {

            //        sc.Close();
            //    }
            //}
            //// hoi
            //return RedirectToAction("Register", "Account");
        //}

        [HttpPost]
        public ActionResult Login(Account account)
        {
            _accountServices.Login(account.username, account.password);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            if (Account.Accounts != null)
            {
                Account.Accounts = null;
            }

            return RedirectToAction("Login", "Account");
        }
    }
}