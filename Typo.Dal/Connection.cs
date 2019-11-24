using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typo.Dal
{
    public abstract class Connection
    {
        protected readonly SqlConnection MssqlConnectionString;

        protected Connection()
        {
            MssqlConnectionString =
                new SqlConnection("Server=mssql.fhict.local;Database=dbi435201;User Id=dbi435201;Password=typo;");
        }
    }
}
