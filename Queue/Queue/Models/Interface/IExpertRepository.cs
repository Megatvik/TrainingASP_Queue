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

        bool HandleQuery(string EID, string QID); //Эксперт с E-ID хочет подписаться на запрос Q-ID
        bool CancelHandleQuery(string EID, string QID); //Эксперт с E-ID хочет Отписаться на запрос Q-ID
        int AdoptClient(string EID, string QID); // Эксперт E-ID принимает первого в очереди Q-ID
        bool SendToSubQueue(string UID, string SubQID); // Эксперт E-ID посылает клиента U-ID вне очереди на запрос SubQID
        bool EndDialog(string EID, string UID); // Эксперт E-ID заканичает разговор с клиентом U-ID
    }
}
