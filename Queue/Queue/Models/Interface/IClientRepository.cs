using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    interface IClientRepository
    {
        bool EnterQueue(int UID, int QID); //Пользователь с U-ID хочет встать в очередь на запрос Q-ID
        bool LeaveQueue(int UID, int QID); //Пользователь с U-ID хочет покинуть очередь на запрос Q-ID
        int QueuePosition(int UID); // Позиция пользователя U-ID в очереди
        bool IsSubQueue(int UID); // Находится ли пользователь U-ID в очереди вне очереди
        bool IsInQueue(int UID); //Находится ли в очереди

    }
}
