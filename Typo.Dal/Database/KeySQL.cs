using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typo.Model.Models;

namespace Typo.Dal.Database
{
    public class KeySQL : Connection
    {
        //generating the key
        public void GenerateKey(string key, int userId)
        {
            var date = DateTime.Today;
            var dateNextYear = date.AddYears(1);
            var datetime = dateNextYear.ToString("MM/dd/yyyy");
            var query = "INSERT INTO License(UserId, LicenseKey, ExpireDate) VALUES('{0}','{1}','{2}')";
            var queryFull = string.Format(query, userId, key, datetime);
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
        //checks the key
        public Key CheckKey(int userId)
        {
            Key key = null;
            var query = "SELECT * FROM License WHERE UserId = '{0}'";
            var queryFull = string.Format(query, userId);
            MssqlConnectionString.Open();
            using (SqlCommand cmd = new SqlCommand(queryFull, MssqlConnectionString))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    key = new Key()
                    {
                        LicenseId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        LicenseKey = reader.GetString(2),
                        LicenseDate = reader.GetDateTime(3)

                    };
                }
            }
            MssqlConnectionString.Close();
            return key;
        }
    }
}
