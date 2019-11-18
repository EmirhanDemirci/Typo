using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Typo.Models;

namespace Typo.Controllers
{
    public class AccountController : Controller
    {
        readonly string _connectionString;

        public AccountController(IConfiguration config)
        {
            _connectionString = config.GetSection("Connection")["MSSQL"];
        }

        public IActionResult Register()
        {
            return View();
        }

        //register account
        [HttpPost]
        public IActionResult Register(Account accounts)
        {

            var query = "INSERT INTO Account(username, password) VALUES('{0}', '{1}')";
            var queryFull = string.Format(query, accounts.username, accounts.password);
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
            return RedirectToAction("Register", "Account");
        }
    }
}