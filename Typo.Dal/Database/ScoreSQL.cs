﻿using System;
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

        public Score ScoreTake(string userId)
        {
            Score score = null;
            var query = "SELECT * FROM ScoreId";
            query += userId;
            query += " WHERE scoreId = '1'";

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
    }
}
