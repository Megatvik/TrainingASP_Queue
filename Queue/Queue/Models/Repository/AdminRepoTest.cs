using Queue.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models.Repository
{
    public class AdminRepoTest:IAdminRepository
    {
        public bool AddQuery(QueryView query)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuery(int QID)
        {
            throw new NotImplementedException();
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
    }
}