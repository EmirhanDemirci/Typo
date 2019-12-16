using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typo.Dal.Database;
using Typo.Model.Models;

namespace Typo.Logic.Services
{
    public class AdminService
    {
        private readonly AccountSQL _accountSql;

        public AdminService()
        {
            _accountSql = new AccountSQL();
        }

        public Account DeleteAccount(int userId)
        {
            _accountSql.GetAllData();
            var account = _accountSql.DeleteAccount(userId);
            return account;
        }
        public List<Account> GetAllAccounts()
        {
            var account = _accountSql.GetAllData();
            return account;
        }
    }
}
