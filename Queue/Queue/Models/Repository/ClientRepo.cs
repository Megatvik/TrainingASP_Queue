using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
using System.Data.SqlClient;
using System.Configuration;
namespace Queue.Models.Repository
{
    public class ClientRepo:IClientRepository
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        public ClientRepo()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["QueueDb"].ConnectionString);
        }
        public bool EnterQueue(string UID, string QID)
        {
            string cmd = @"EXECUTE EnterQueue @uid, @qid ";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@uid", UID);
            command.Parameters.AddWithValue("@qid", QID);
            return ExecuteCommand();
        }

        public bool LeaveQueue(string UID)
        {
            string cmd = @"EXECUTE LeaveQueue @uid ";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@uid", UID);
            return ExecuteCommand();
        }

        public int QueuePosition(string UID)
        {
            throw new NotImplementedException();
        }

        public bool IsSubQueue(string UID)
        {
            throw new NotImplementedException();
        }
        public bool IsInQueue(string UID)
        {
            string cmd = @"SELECT ID_query FROM Client WHERE ID = @uid";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@uid", UID);
            try
            {
                connect.Open();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    bool flag = reader.IsDBNull(0);
                    connect.Close();
                    return flag;
                }
            }
            catch (SqlException) { }
            connect.Close();
            return false;
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
            catch (SqlException err) { connect.Close(); }

            connect.Close();
            return flag;
        }
    }
}