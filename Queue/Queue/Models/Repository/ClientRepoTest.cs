using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;
namespace Queue.Models.Repository
{
    public class ClientRepoTest:IClientRepository
    {
        public bool EnterQueue(int UID, int QID)
        {
            throw new NotImplementedException();
        }

        public bool LeaveQueue(int UID, int QID)
        {
            throw new NotImplementedException();
        }

        public int QueuePosition(int UID)
        {
            throw new NotImplementedException();
        }

        public bool IsSubQueue(int UID)
        {
            throw new NotImplementedException();
        }
        public bool IsInQueue(int UID)
        {
            return true;
        }
    }
}