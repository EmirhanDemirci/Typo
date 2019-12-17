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
    public class AccountSQL : Connection, ICrud<Account> 
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

        public bool Delete(Account obj)
        {
            const string query = "DELETE FROM [Account] WHERE UserId = {0}";
            var queryFull = string.Format(query, obj.UserId);
            MssqlConnectionString.Open();
            using (var command = new SqlCommand(queryFull, MssqlConnectionString))
            {
                try
                {
                    command.ExecuteNonQuery();
                    MssqlConnectionString.Close();
                    return true;
                }
                catch
                {
                    MssqlConnectionString.Close();
                    return false;
                }
            }
        }

        public Account Login(string mailUser, string password)
        {
            Account account = null;
            var query = "SELECT * FROM Account WHERE mailUser = '{0}' AND password = '{1}'";
            var queryFull = string.Format(query, mailUser, password);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account()
                    {
                        UserId = reader.GetInt32(0),
                        MailUser = reader.GetString(1),
                        Password = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        IsAdmin = reader.GetInt32(6),
                        IsDocent = reader.GetInt32(7)
                    };
                }
            }
            MssqlConnectionString.Close();
            return account;
        }

        public void Register(string mailUser, string password, string firstname, string lastname, DateTime birthdate, int isAdmin, int isDocent)
        {
                var query = "INSERT INTO Account(MailUser, Password, FirstName, LastName, BirthDate, IsAdmin, IsDocent) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
                var queryFull = string.Format(query, mailUser, password, firstname, lastname, birthdate.ToString("MM/dd/yyyy"), isAdmin, isDocent);
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

        public List<Account> GetAllData()
        {
            Account account;
            List<Account> accounts = new List<Account>();
            var query = "Select * FROM Account";
            var queryFull = string.Format(query);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account()
                    {
                        UserId = reader.GetInt32(0),
                        MailUser = reader.GetString(1),
                        Password = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        IsAdmin = reader.GetInt32(6),
                        IsDocent = reader.GetInt32(7)
                    };
                    accounts.Add(account);
                }
            }
            MssqlConnectionString.Close();
            return accounts;
        }

        public Account DeleteAccount(int userId)
        {
            Account account = null;
            var query = "Delete FROM Account WHERE UserId = '{0}'";
            var queryFull = string.Format(query, userId);
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
            MssqlConnectionString.Close();
            return account;
        }
            
    }
}
