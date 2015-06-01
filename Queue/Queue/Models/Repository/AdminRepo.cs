using Queue.Models.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Queue.Models.Repository
{
    public class AdminRepo:IAdminRepository
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        public AdminRepo()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["QueueDb"].ConnectionString);
        }
        public bool AddQuery(string name)
        {         
            string cmd =@"EXECUTE AddQuery @name";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@name", name);          
            return ExecuteCommand();
        }

        public bool DeleteQuery(int QID)
        {
            string cmd =
            @"
            DELETE FROM [Queue].[dbo].[Query]
            WHERE ID = @qid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@qid", QID);
            return ExecuteCommand();
        }

        public bool SetWaitResponceTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public bool SetAlertNumber(int number)
        {
            throw new NotImplementedException();
        }


        public bool EditQuery(QueryView query)
        {
            throw new NotImplementedException();
        }
        private bool ExecuteCommand()
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