using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARwashManagementSystem
{
    public abstract class DbConnections
    {
        public readonly string connectionString;

        public DbConnections()
        {
            connectionString = "Data Source = MEGI\\SQLEXPRESS01; Initial Catalog = CARWASH; Integrated Security = True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
