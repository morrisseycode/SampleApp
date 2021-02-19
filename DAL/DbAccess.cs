using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp.DAL
{
    public class DbAccess
    {

        public DbAccess()
        {
        }

        public object TriggerSecurityWarning(string connString, string name, string password)
        {
            SqlConnection someConnection = new SqlConnection(connString);
            SqlCommand someCommand = new SqlCommand();
            someCommand.Connection = someConnection;

            someCommand.CommandText = "SELECT SecretInfo FROM Users " +
               "WHERE Username='" + name +
               "' AND Password='" + password + "'";

            object secretInfo;

            try
            {
                someConnection.Open();
                secretInfo = someCommand.ExecuteScalar();
                someConnection.Close();
            }
            catch(Exception ex)
            {
                secretInfo = null;
            }
            return secretInfo;
        }
    }
}
