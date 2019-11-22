using System;
using System.Collections.Generic;
using System.Text;
using Typo.Dal.Interfaces;
using Typo.Model.Models;

namespace Typo.Dal.Memory
{
    public class AccountMemoryContext : IAccountRepository
    {
        private readonly List<Account> _accounts;

        public Account GetByLogin(string username, string password)
        {
            foreach (var user in _accounts)
            {
                if ((username == user.username) && (password == user.password))
                    return user;
            }
            return null;
        }

        public bool Add(Account entity)
        {
            //entity.Active = true;
            //entity.Admin = false;
            //entity.ProfilePicture = "Blank-profile.png";
            //entity.CoverPicture = "Blank-cover.png";

            //var id = 1;
            //foreach (var user in _accounts)
            //{
            //    if (id <= user.UserId)
            //        id = user.UserId + 1;
            //}

            //entity.UserId = id;
            //_users.Add(entity);
            return true;
        }
    }
}
