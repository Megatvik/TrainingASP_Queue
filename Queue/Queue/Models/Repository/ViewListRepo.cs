using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
using System.Data.SqlClient;
using System.Configuration;
namespace Queue.Models.Repository
{
    public class ViewListRepo: IViewRepo
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        public ViewListRepo()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["QueueDb"].ConnectionString);
        }
        public List<QueryView> SelectAllQuery()
        {
            List<QueryView> list = new List<QueryView>();
            string cmd = @"Select * from Query";
            command = new SqlCommand(cmd,connect);
            try
            {
                connect.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    QueryView query = new QueryView();
                    query.ID = (string)reader["ID"];
                    query.Name = (string)reader["Name"];
                    query.Experts = (int)reader["Experts"];
                    query.QueueCount = (int)reader["QueueCount"];
                    query.SubQueueCount = (int)reader["SubQueueCount"];
                    list.Add(query);
                }
                reader.Close();
            }
            catch (SqlException) { }

            connect.Close();
            return list;
        }

        public List<ExpertView> SelectAllExperts()
        {
            List<ExpertView> list = new List<ExpertView>() 
            {
                new ExpertView() 
                {
                    Name="qwe",
                     IsAuthorize=true,
                      IsWorking=true,
                    ProcessingQuery = new List<QueryView>()
                    {
                        new QueryView() {Name="123123"},
                        new QueryView() {Name="qweqwewqe"},
                        new QueryView() {Name="QueryQuery"}
                    }
                },
                new ExpertView() 
                {
                    Name="asd",
                    ProcessingQuery = new List<QueryView>()
                    {
                        new QueryView() {Name="123123"},
                        new QueryView() {Name="qweqwewqe"},
                        new QueryView() {Name="QueryQuery"}
                    }
                }
            };
            return list;
        }

        public List<QueryView> SelectProcessingByExpert(string EID)
        {
            List<QueryView> list = new List<QueryView>();
            string cmd = @"Select * from ProcessingQuery where ID_expert = @eid";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@eid", EID);
            try
            {
                connect.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    QueryView query = new QueryView();
                    query.ID = (string)reader["ID"];
                    query.Name = (string)reader["Name"];
                    query.Experts = (int)reader["Experts"];
                    query.QueueCount = (int)reader["QueueCount"];
                    query.SubQueueCount = (int)reader["SubQueueCount"];
                    list.Add(query);
                }
                reader.Close();
            }
            catch (SqlException) { connect.Close(); }

            connect.Close();
            return list;
        }

        public List<ProcessingView> SelectAllProcessingList()
        {
            throw new NotImplementedException();
        }
        public QueueView SelectQueueInfo(string UID)
        {
            QueueView view = new QueueView();

            string cmd = @"
                        Select Query.Name,Client.QueueNumber, Client.SubQueue
                        from Client INNER JOIN Query 
                        ON Query.ID = Client.ID_query
                        where Client.ID = @uid";
            command = new SqlCommand(cmd, connect);
            command.Parameters.AddWithValue("@uid", UID);
            try
            {
                connect.Open();
                reader = command.ExecuteReader();
                reader.Read();
                view.Name = (string)reader["Name"];
                view.Position = (int)reader["QueueNumber"];
                view.IsSubQueue = (bool)reader["SubQueue"];
                view.WaitingTime = view.Position * 5;
                reader.Close();
            }
            catch (SqlException) { }

            connect.Close();
            return view;
        }
    }
}