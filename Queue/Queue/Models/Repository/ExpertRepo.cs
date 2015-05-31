using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue.Models.Repository
{
    public class ExpertRepo:IExpertRepository
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        public ExpertRepo()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["QueueDb"].ConnectionString);
        }
        public bool HandleQuery(string EID, string QID)
        {
            string cmd = @"EXECUTE Subscribe @eid, @qid ";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@qid", QID);
            return ExecuteCommand();
        }

        public string AdoptClient(string EID, string QID)
        {
            string cmd = "EXECUTE AdoptClient @eid, @qid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@qid", QID);
            connect.Open();
            string CID = (string)command.ExecuteScalar();
            connect.Close();
            //Логика для поиска первого клиента из очереди и возврата его ID
            return CID;
        }

        public bool SendToSubQueue(string EID, string SubQID)
        {
            string cmd = "EXECUTE SendToSubQueue @eid, @qid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@qid", SubQID);
            return ExecuteCommand();
        }

        public bool EndDialog(string EID, string UID)
        {
            string cmd = "EXECUTE EndDialog @eid, @uid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@uid", UID);
            return ExecuteCommand();
        }
        public bool CancelHandleQuery(string EID, string QID)
        {
            string cmd = @"EXECUTE Unsubscribe @eid, @qid ";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@qid", QID);
            return ExecuteCommand();
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