using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Data
{
    public class Connection
    {
        public static IDbConnection GetDbConnection()
        {
            IDbConnection connection = new SqlConnection("Data Source=94.73.147.7;Initial Catalog=u8719880_mobtask;User ID=u8719880_taskuse;Password=GAla47D3");

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            return connection;
        }
    }
}
