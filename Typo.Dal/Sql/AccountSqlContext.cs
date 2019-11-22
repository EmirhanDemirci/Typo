using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Typo.Dal.Interfaces;
using Typo.Model.Models;

namespace Typo.Dal.Sql
{
    public class AccountSqlContext : Connection, IAccountRepository
    {
        public Account GetByLogin(string username, string password)
        {
            Account account = null;
            MSSQLConnectionString.Open();
            var query = "SELECT * FROM Account WHERE username = '{0}' AND password = '{1}'";
            var queryFull = string.Format(query, account.username, account.password);
            using (SqlCommand cmd = new SqlCommand(queryFull, MSSQLConnectionString))
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
            MSSQLConnectionString.Close();
            return account;
        }
        public bool Add(Account entity)
        {
            MSSQLConnectionString.Open();
            var query = "INSERT INTO Account(username, password) VALUES('{0}', '{1}')";
            var queryFull = string.Format(query, entity.username, entity.password);
            using (SqlCommand cmd = new SqlCommand(queryFull, MSSQLConnectionString))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MSSQLConnectionString.Close();
                    return true;
                }
                catch
                {

                    MSSQLConnectionString.Close();
                    return false;
                }
            }
        }
    }
}
