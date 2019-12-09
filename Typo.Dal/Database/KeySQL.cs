using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typo.Dal.Database
{
    public class KeySQL : Connection
    {
        public void GenerateKey(string key, int userId)
        {
            var query = "INSERT INTO License(UserId, LicenseKey, ExpireDate) VALUES('{0}','{1}','{2}')";
            var queryFull = string.Format(query, userId, key, DateTime.Today.AddYears(1));
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
