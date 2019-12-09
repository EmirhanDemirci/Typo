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
        public void GenerateKey(string key)
        {
            var query = "INSERT INTO License(LicenseKey) VALUES('{0}')";
            var queryFull = string.Format(query, key);
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
