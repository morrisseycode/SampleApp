using System;
using System.Collections.Generic;
using System.Data;
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
            using (var connection = new SqlConnection(connString))
            {
                var query1 = "SELECT ITEM,PRICE FROM PRODUCT WHERE ITEM_CATEGORY='"
                  + name + "' ORDER BY PRICE";
                var adapter = new SqlDataAdapter(query1, connection);
                var result = new DataSet();
                try
                {
                    adapter.Fill(result);
                }
                catch (Exception ex)
                {

                }
                return result;
            }
            //SqlConnection someConnection = new SqlConnection(connString);
            //SqlCommand someCommand = new SqlCommand();
            //someCommand.Connection = someConnection;

            //someCommand.CommandText = "SELECT SecretInfo FROM Users " +
            //   "WHERE Username='" + name +
            //   "' AND Password='" + password + "'";

            //object secretInfo;

            //try
            //{
            //    someConnection.Open();
            //    secretInfo = someCommand.ExecuteScalar();
            //    someConnection.Close();
            //}
            //catch(Exception ex)
            //{
            //    secretInfo = null;
            //}
            //return secretInfo;
        }
    }
}
