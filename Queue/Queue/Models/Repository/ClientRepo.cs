using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Queue.Models.Repository
{
    public class ClientRepo:SqlRepository,IClientRepository
    {
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
            catch (SqlException) {}
            connect.Close();
            return false;
        }
    }
}