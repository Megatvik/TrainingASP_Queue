using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models.Interface;

namespace Queue.Models.Repository
{
    public class ExpertRepoTest:IExpertRepository
    {
        public bool HandleQuery(int EID, int QID)
        {
            //Сдесь будет подписываться эксперт на запрос
            return true;
        }

        public int AdoptClient(int EID, int QID)
        {
            int CID=1;
            //Логика для поиска первого клиента из очереди и возврата его ID
            return CID;
        }

        public bool SendToSubQueue(int UID, int SubQID)
        {
            throw new NotImplementedException();
        }

        public bool EndDialog(int EID, int UID)
        {
            throw new NotImplementedException();
        }
        public bool CancelHandleQuery(int EID, int QID)
        {
            //Сдесь эксперт отписывается от запроса
            return true;
        }
    }
}