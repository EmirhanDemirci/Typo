using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Typo.Model.Models;

namespace Logic
{
    public class AccountServices
    {
        private readonly AccountRepository _repo;

        public AccountServices(AccountRepository repo)
        {
            _repo = repo;
        }

        public Account Login(string username, string password)
        {
            // Checking for null values.
            if ((username == null) || (password == null))
                throw new ExceptionHandler("NotImplemented", "Not all fields are inserted");
            // Checking if user exists.
            var user = _repo.GetByLogin(username, password = PasswordHasher(password));
            if (user == null)
                throw new ExceptionHandler("User", "User not found");
            return user;
        }

    }
}
