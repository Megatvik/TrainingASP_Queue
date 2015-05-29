using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    interface IClientRepository
    {
        bool EnterQueue(string UID, string QID); //Пользователь с U-ID хочет встать в очередь на запрос Q-ID
        bool LeaveQueue(string UID); //Пользователь с U-ID хочет покинуть очередь
        int QueuePosition(string UID); // Позиция пользователя U-ID в очереди
        bool IsSubQueue(string UID); // Находится ли пользователь U-ID в очереди вне очереди
        bool IsInQueue(string UID); //Находится ли в очереди

    }
}
