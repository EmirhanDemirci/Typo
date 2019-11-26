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

        
        public IActionResult ScoreCheck()
        {
            return View();
        }

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
            return RedirectToAction("ScoreInput", "Score");
        }







        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScoreCheck(Score score)
        {
            var IdUser = ScoreResult(score);
            if (IdUser != null)
            {

                
                return RedirectToAction("ScoreCheck", "Score");

            }
            return View();
        }

        private Score ScoreResult(Score score)
        {
            Score scores = null;
            var query = "SELECT * FROM ScoreId";

            
            query += score;
            query += " WHERE score = '{0}'";
            var queryFull = string.Format(query, scores.score);
            var sc = new SqlConnection(_connectionString);
            sc.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, sc))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    scores = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        score = reader.GetString(1)
                    };
                }
            }
            return scores;
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