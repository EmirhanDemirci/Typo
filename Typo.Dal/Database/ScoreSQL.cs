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


            var query = "INSERT INTO ScoreId1(score2) VALUES('{0}')";



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
