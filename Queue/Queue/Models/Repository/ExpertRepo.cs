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

        public int AdoptClient(string EID, string QID)
        {
            int CID=1;
            //Логика для поиска первого клиента из очереди и возврата его ID
            return CID;
        }

        public bool SendToSubQueue(string UID, string SubQID)
        {
            throw new NotImplementedException();
        }

        public bool EndDialog(string EID, string UID)
        {
            throw new NotImplementedException();
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