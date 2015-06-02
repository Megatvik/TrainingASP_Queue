using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Queue.Models.Repository
{
    public class SqlRepository
    {
       protected SqlConnection connect;
       protected SqlCommand command;
       protected SqlDataReader reader;

       protected SqlRepository()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["QueueDb"].ConnectionString);
        }

        protected bool ExecuteCommand()
        {
            bool flag = false;

            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (SqlException) { connect.Close(); }

            connect.Close();
            return flag;
        }
    }
}