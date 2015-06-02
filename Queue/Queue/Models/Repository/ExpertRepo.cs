using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue.Models.Repository
{
    public class ExpertRepo:SqlRepository, IExpertRepository
    {
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
            string UID="0";
            string cmd = "EXECUTE AdoptClient @eid, @qid";
            command = new SqlCommand(cmd,connect);
            command.Parameters.AddWithValue("@eid", EID);
            command.Parameters.AddWithValue("@qid", QID);
            try
            {
                connect.Open();
                UID = (string)command.ExecuteScalar();
            }
            catch (Exception) { }
            connect.Close();
            return UID;
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
    }
}