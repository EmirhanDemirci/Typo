using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Reflection.Emit;
using Typo.Dal.Database;
using Typo.Model.Models;
namespace Typo.Logic.Services
{
    public class AccountService
    {
        private readonly AccountSQL _accountSql;

        public AccountService()
        {
            _accountSql = new AccountSQL();
        }
        
        public Account Login(string mailUser, string password)
        {
            var account = _accountSql.Login(mailUser, password);
            if (mailUser != null || password != null || account != null)
            {
                return account;
            }
            return null;
        }

        public void Register(string username, string password, string firstname, string lastname, DateTime birthdate)
        {
            if (username != null || password != null)
            {
                _accountSql.Register(username, password, firstname, lastname, birthdate);
            }
        }
    }
}
