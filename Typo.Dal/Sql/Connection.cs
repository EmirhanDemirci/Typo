using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Typo.Dal
{
    public abstract class Connection
    {
        // Hard coded connectionstring.
        protected readonly SqlConnection MSSQLConnectionString;

        protected Connection()
        {
            MSSQLConnectionString =
                new SqlConnection("Server=mssql.fhict.local;Database=dbi435201;User Id=dbi435201;Password=typo;");
        }
    }
}
