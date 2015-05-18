using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models;

namespace Queue.Models.Interface
{
    public interface IRepository
    {
        #region Client Methods
        bool EnterQueue(int UID, int QID); //Пользователь с U-ID хочет встать в очередь на запрос Q-ID
        bool LeaveQueue(int UID, int QID); //Пользователь с U-ID хочет покинуть очередь на запрос Q-ID

        #endregion

        #region Expert Methods
        bool HandleQuery(int EID, int QID); //Эксперт с E-ID хочет подписаться на запрос Q-ID
        bool AdoptClient(int EID, int QID); // Эксперт принимает первого в очереди
        bool SendToSubQueue(int UID, int SubQID); // Эксперт посылает клиента U-ID вне очереди на запрос SubQID
        
        #endregion

        #region Admin Methods
        bool ClearProcessing(int EID); //Отписать эксперта от всех запросов
        bool AddQuery(QueryView query); //Добавить новый вид запроса

        #endregion

        #region List Methods
        List<QueryView> SelectAllQuery(); // Возвращает список всех запросов 

        #endregion
    }
}