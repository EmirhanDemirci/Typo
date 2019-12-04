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

        public void Delete(Account obj)
        {
            throw new NotImplementedException();
        }








        public void ScoreCreate(string userid) //\/\/ Maken van nieuwe column voor nieuwe user in tabel
        {


            //var query = "INSERT INTO ScoreId1(score) VALUES('{0}')";

            var query = "ALTER TABLE Score ADD score";
            query += userid;
            query += " nvarchar(255) DEFAULT NULL";
            
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



            var query1 = "UPDATE Score SET score";
            query1 += userid;
            query1 += " = 0 WHERE scoreId = 1";
            var queryFull1 = string.Format(query1);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull1, MssqlConnectionString))
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









        /* Dit was voor het testen in het begin. het neemt gewoon de eerste score uit de tabel

        public Score ScoreTake(string userId)
        {
            
            var query = "SELECT * FROM ScoreId";
            query += userId;
            query += " WHERE scoreId = '1'";


            Score score = ScoreLocalNormal(query);
            
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
        */


        /* Dit was de oorspronkelijke score input werkt alleen op eerste rij

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
        public void ScoreInput(string score, string userid) // test for create column input
        {
            
            //Nieuwe database
            // aanpassen variables.
            // code bijwerk en afronden.
            // input relevant maken aan de code
            // variables relevant maken aan de database
            // code bijwerken en je hebt iets om te laten zien aan einde sprint.
            // aan het einde van de sprint
           

            // COLUMN = userID    ROW = how many score's is new score necesery    SCORE = input data   SCOREID = nodig
            // je gebruikt de user id voor de column daarmee run je een query

            // run query voor laatste score ID
            var query1 = "SELECT TOP 1 * FROM Score ORDER BY scoreId DESC";
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
            var query2 = "SELECT TOP 1 * FROM Score WHERE score";
            query2 += userid;
            query2 += " >= 0 ORDER BY scoreId DESC";
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


            var query3 = "SELECT score";
            query3 += userid;
            query3 += " FROM Score WHERE scoreId";
            //query3 += userid;
            query3 += " = 1";
            Score score3 = null;
            var queryFull3 = string.Format(query3);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull3, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score3 = new Score()
                    {
                        score = reader.GetString(0),

                    };
                }

            }
            MssqlConnectionString.Close();
            
            
            if (score3.score == "0")
            {
                var query = "UPDATE Score SET score";
                query += userid;
                query += " = '{0}' WHERE scoreId = 1";
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
            else if (score1.scoreId == score2.scoreId)
            {
                var query = "INSERT INTO Score(score";
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

                var query = "UPDATE Score SET score";
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
            Score score = null;
            var query = "SELECT TOP 1 score";
            query += userId;
            query += " FROM Score ORDER BY score";
            query += userId;
            query += " DESC";


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


        
        public Score ScoreAvg(string userId)
        {

            // SELECT AVG(CAST([score1] as int)) FROM Score  
            // voor als nvarchar als average
            Score score = null;
            var query = "SELECT AVG(CAST([score";
            query += userId;
            query += "] as int)) FROM Score";


            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    score = new Score()
                    {
                        score = reader.GetInt32(0).ToString(),
                    };
                }
            }


            return score;
        }

        


        public Score ScoreCurrent(string userId)
        {
            Score score = null;
            var query = "SELECT TOP 1 score";
            query += userId;
            query += " FROM Score ORDER BY scoreId DESC"; 




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
