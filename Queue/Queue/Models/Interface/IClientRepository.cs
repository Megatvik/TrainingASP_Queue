using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    public interface IClientRepository
    {
        bool EnterQueue(string UID, string QID); //Пользователь с U-ID хочет встать в очередь на запрос Q-ID
        bool LeaveQueue(string UID); //Пользователь с U-ID хочет покинуть очередь
        bool IsInQueue(string UID); //Находится ли в очереди

    }
}
