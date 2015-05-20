using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
namespace Queue.Models.Repository
{
    public class ViewListRepoTest: IViewRepo
    {
        public List<QueryView> SelectAllQuery()
        {
            List<QueryView> list = new List<QueryView>() 
            {
                new QueryView(){NameQuery="123", ExpertsCount=1, QueueCount=0, SubQueueCount=0},
                new QueryView(){NameQuery="qwe", ExpertsCount=1, QueueCount=0, SubQueueCount=0},
                new QueryView(){NameQuery="asd", ExpertsCount=1, QueueCount=0, SubQueueCount=0}
            };
            return list;
        }

        public List<ExpertView> SelectAllExperts()
        {
            throw new NotImplementedException();
        }

        public List<QueryView> SelectProcessingByExpert(int EID)
        {
            Random rnd = new Random();
            QueryView query = new QueryView();
            query.NameQuery = rnd.Next().ToString();
            query.QueueCount = 2;
            query.SubQueueCount = 0;
            List<QueryView> list = new List<QueryView>();
            list.Add(query);
            return list;
        }

        public List<ProcessingView> SelectAllProcessingList()
        {
            throw new NotImplementedException();
        }
    }
}