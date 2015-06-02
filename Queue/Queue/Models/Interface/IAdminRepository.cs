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
    }
}
