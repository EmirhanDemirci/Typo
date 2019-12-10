using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Typo.Dal.Database;
using Typo.Model.Models;

namespace Typo.Logic.Services
{
    public class KeyService
    {
        private readonly KeySQL _keySql;
        public KeyService()
        {
            _keySql = new KeySQL();
        }
        public void GenerateKey(string key, int userId)
        {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int l = 0; l < stringChars.Length; l++)
                {
                    stringChars[l] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                key = finalString;
                _keySql.GenerateKey(key, userId);
        }
        public Key CheckLicense(int userId)
        {
            if (userId != null)
            {
                var key = _keySql.CheckKey(userId);
                return key;
            }
            return null;
         
        }
    }
}
