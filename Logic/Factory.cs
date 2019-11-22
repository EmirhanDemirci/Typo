using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Typo.Dal.Memory;

namespace Logic
{
    public class Factory
    {
        private readonly string _context;
        public Factory()
        {
            _context = null;
        }
        public Factory(IConfiguration config)
        {
            _context = config.GetSection("Database")["Type"];
        }

        public AccountServices AccountService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new AccountServices(new AccountRepository(new AccountSqlContext()));
                default:
                    return new AccountServices(new AccountRepository(new AccountMemoryContext()));
            }
        }
    }
}
