using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
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
        
        public Account Login(string username, string password)
        {
            var account = _accountSql.Login(username, password);

            if (username == "" || password == "")
            {
                return null;
            }
            return account;
        }

        public void Register(string username, string password)
        {
            _accountSql.Register(username, password);
        }
    }
}
