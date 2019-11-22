using System;
using System.Collections.Generic;
using System.Text;
using Typo.Model.Models;

namespace Typo.Dal.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        //Account GetByUserName(string username);
        Account GetByLogin(string username, string password);
        //Account GetFullUser(int id);
    }
}
