using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    interface IAdminRepository
    {
        bool AddQuery(string query); //Добавить новый вид запроса
        bool DeleteQuery(int QID); //Удалить вид запроса
        bool SetWaitResponceTime(DateTime time); // Сколько ждать до того, как пользователь подтвердит готовность
        bool SetAlertNumber(int number); // Сколько раз предупреждать пользователя о его очереди    
        bool EditQuery(QueryView query);
    }
}
