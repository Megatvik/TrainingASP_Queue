using Queue.Models.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Queue.Models.Repository
{
    public class AdminRepo:SqlRepository, IAdminRepository
    {
        public bool AddQuery(string name)
        {         
            string cmd =@"EXECUTE AddQuery @name";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@name", name);          
            return ExecuteCommand();
        }

        public bool DeleteQuery(int QID)
        {
            string cmd =@"DELETE FROM Query WHERE ID = @qid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@qid", QID);
            return ExecuteCommand();
        }
    }
}