using System;
using System.Collections.Generic;
using System.Text;
using Typo.Dal.Interfaces;
using Typo.Dal.Memory;
using Typo.Dal.Sql;
using Typo.Model.Models;

namespace Typo.Dal.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IRepository<Account> context) : base(context)
        {
        }
        public Account GetByLogin(string username, string password)
        {
            return RightContext().GetByLogin(username, password);
        }
        private IAccountRepository RightContext()
        {
            switch (Context)
            {
                case AccountSqlContext context:
                    return context;
                case AccountMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
