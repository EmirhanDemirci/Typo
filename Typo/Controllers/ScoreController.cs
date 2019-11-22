using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Typo.Controllers;
using Typo.Models;


namespace Typo.Controllers
{
    public class ScoreController : Controller
    {
        readonly string _connectionString;
        public ScoreController(IConfiguration config)
        {
            _connectionString = config.GetSection("Connection")["MSSQL"];
        }

        /*
        public IActionResult Register()
        {
            return View();
        }*/

        public IActionResult ScoreInput()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ScoreInput(Score scores)
        {
            var query = "INSERT INTO ScoreId1(score) VALUES('{0}')";
            var queryFull = string.Format(query, scores.score);
            var sc = new SqlConnection(_connectionString);
            sc.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, sc))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    sc.Close();
                }
                catch
                {

                    sc.Close();
                }
            }
            // hoi
            return RedirectToAction("ScoreInput", "Score");
        }







        /*

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account objUser)
        {
            var account = LoginUser(objUser);
            if (account != null)
            {

                Account.Accounts = account;
                return RedirectToAction("Index", "Home");

            }
            return View();
        }

        private Account LoginUser(Account accounts)
        {
            Account account = null;
            var query = "SELECT * FROM Account WHERE username = '{0}' AND password = '{1}'";
            var queryFull = string.Format(query, accounts.username, accounts.password);
            var sc = new SqlConnection(_connectionString);
            sc.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, sc))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account()
                    {
                        userId = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2)
                    };
                }
            }
            return account;
        }


        /*
        public IActionResult LogOut()
        {
            if (Account.Accounts != null)
            {
                Account.Accounts = null;
            }

            return RedirectToAction("Login", "Account");
        }
        */
    
    }
}