using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    interface IExpertRepository
    {

        bool HandleQuery(int EID, int QID); //Эксперт с E-ID хочет подписаться на запрос Q-ID
        bool CancelHandleQuery(int EID, int QID); //Эксперт с E-ID хочет Отписаться на запрос Q-ID
        int AdoptClient(int EID, int QID); // Эксперт E-ID принимает первого в очереди Q-ID
        bool SendToSubQueue(int UID, int SubQID); // Эксперт E-ID посылает клиента U-ID вне очереди на запрос SubQID
        bool EndDialog(int EID, int UID); // Эксперт E-ID заканичает разговор с клиентом U-ID
    }
}
