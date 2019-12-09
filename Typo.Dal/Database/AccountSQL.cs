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

        public void Delete(Account obj)
        {
            throw new NotImplementedException();
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
                        IsAdmin = reader.GetInt32(6)
                    };
                }
            }
            MssqlConnectionString.Close();
            return account;
        }

        public void Register(string mailUser, string password, string firstname, string lastname, DateTime birthdate, int isAdmin)
        {
                var query = "INSERT INTO Account(MailUser, Password, FirstName, LastName, BirthDate, IsAdmin) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                var queryFull = string.Format(query, mailUser, password, firstname, lastname, birthdate, isAdmin);
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
