using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typo.Dal.Interfaces;
using Typo.Model.Models;

namespace Typo.Dal.Database
{
    public class ScoreSQL : Connection, ICrud<Account>
    {
        public void Create(Account obj)
        {
            throw new NotImplementedException();
        }

        public Account Read(Account obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Account obj)
        {
            throw new NotImplementedException();
        }








        public void ScoreCreate(string score)
        {


            //var query = "INSERT INTO ScoreId1(score) VALUES('{0}')";

            var query = "ALTER TABLE ScoreId1 ADD score2 nvarchar(255)";

            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MssqlConnectionString.Close();
                }
                catch
                {

                    MssqlConnectionString.Close();
                }
            }
        }




        public void Delete(Account obj)
        {
            throw new NotImplementedException();
        }







        public Score ScoreTake(string userId)
        {
            
            var query = "SELECT * FROM ScoreId";
            query += userId;
            query += " WHERE scoreId = '1'";


            Score score = ScoreLocalNormal(query);
            /*
            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        score = reader.GetString(1),
                    };
                }
            }
            */
            return score;
        }







        /*

        public void ScoreInput(string score)
        {

                      
            var query = "INSERT INTO ScoreId1(score) VALUES('{0}')";



            var queryFull = string.Format(query, score);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MssqlConnectionString.Close();
                }
                catch
                {

                    MssqlConnectionString.Close();
                }
            }
        }

        */
        public void ScoreInput(string score) // test for create column input
        {
            string userid = "2";

            // COLUMN = userID    ROW = how many score's is new score necesery    SCORE = input data   SCOREID = nodig
            // je gebruikt de user id voor de column daarmee run je een query

            // run query voor laatste score ID
            var query1 = "SELECT TOP 1 * FROM ScoreId1 ORDER BY scoreId DESC";


            Score score1 = null;
            var queryFull1 = string.Format(query1);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull1, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score1 = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        
                    };
                }

            }
            MssqlConnectionString.Close();





















            // run query voor laatste voor laatste scoreID in relevante column
            var query2 = "SELECT TOP 1 * FROM ScoreId1 WHERE score";
            query2 += userid;
            query2 += " > 0 ORDER BY scoreId DESC";

            Score score2 = null;
            var queryFull2 = string.Format(query2);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull2, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score2 = new Score()
                    {
                        scoreId = reader.GetInt32(0),

                    };
                }

            }
            MssqlConnectionString.Close();












            if (score1.scoreId == score2.scoreId)
            {
                var query = "INSERT INTO ScoreId1(score";
                query += userid;
                query += ") VALUES('{0}')";
                var queryFull = string.Format(query, score);
                MssqlConnectionString.Open();
                using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MssqlConnectionString.Close();
                    }
                    catch
                    {

                        MssqlConnectionString.Close();
                    }
                }
            }
            else if(score1.scoreId > score2.scoreId)
            {
                int scorenumber = score2.scoreId;
                scorenumber = scorenumber + 1;
                string numberscore = scorenumber.ToString();
                var query = "UPDATE ScoreId1 SET score";
                query += userid;
                query += " = '{0}' WHERE scoreId = ";
                query += numberscore;
                var queryFull = string.Format(query, score);
                MssqlConnectionString.Open();
                using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MssqlConnectionString.Close();
                    }
                    catch
                    {

                        MssqlConnectionString.Close();
                    }
                }
            }

            // Vergelijk laatste score id en relevante score ID

            // als gelijk gebruik insert om nieuwe row aan te maken.
            // als relevante score ID kleiner is dan laatste score ID update relevanteSCoreID +1

            //var query = "INSERT INTO ScoreId1(score2) VALUES('{0}')";
            //var query = "UPDATE ScoreId1 SET score2 = 123 WHERE scoreId = 8";

            

            
        }









        public Score ScoreHigh(string userId)
        {
            
            var query = "SELECT TOP 1 * FROM ScoreId1 ORDER BY score DESC";

            Score score = ScoreLocalNormal(query);
            /*

            var queryFull = string.Format(query);

            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        score = reader.GetString(1),
                    };
                }
            }
            */


            return score;
        }


        
        public Score ScoreAvg(string userId)
        {
            Score score = null;
            var query = "SELECT AVG(score) FROM ScoreId1";
            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        
                        score = reader.GetString(0),
                    };
                }
            }

            
            return score;
        }

        


        public Score ScoreCurrent(string userId)
        {

            var query = "SELECT TOP 1 * FROM ScoreId1 ORDER BY scoreId DESC";
            Score score = ScoreLocalNormal(query);


            /*
            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        score = reader.GetString(1),
                    };
                }
             
            }
            */
            return score;

        }





        private Score ScoreLocalNormal(string query)
        {
            Score score = null;
            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        scoreId = reader.GetInt32(0),
                        score = reader.GetString(1),
                    };
                }

            }
            return score;
        }





























































    }
}
