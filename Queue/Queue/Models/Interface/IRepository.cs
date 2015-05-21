using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queue.Models;
using System.Data.SqlClient;

namespace Queue.Models.Interface
{
    public interface IViewRepository
    {

        #region Client Methods


        #endregion

        #region Expert Methods

        bool HandleQuery(int EID, int QID); //Эксперт с E-ID хочет подписаться на запрос Q-ID
        bool AdoptClient(int EID, int QID); // Эксперт E-ID принимает первого в очереди Q-ID
        bool SendToSubQueue(int UID, int SubQID); // Эксперт E-ID посылает клиента U-ID вне очереди на запрос SubQID
        bool EndDialog(int EID, int UID); // Эксперт E-ID заканичает разговор с клиентом U-ID
        #endregion

        #region Admin Methods

       // bool ClearProcessing(int EID); //Отписать эксперта от всех запросов
        bool AddQuery(QueryView query); //Добавить новый вид запроса
        bool DeleteQuery(QueryView query); //Удалить вид запроса
        bool SetWaitResponceTime(DateTime time); // Сколько ждать до того, как пользователь подтвердит готовность
        bool SetAlertNumber(int number); // Сколько раз предупреждать пользователя о его очереди
        
        #endregion

        #region List Methods

        List<QueryView> SelectAllQuery(); // Возвращает список всех запросов 
        List<ExpertView> SelectAllExperts(); //Возвращает список всех экспертов
        List<ProcessingView> SelectProcessingByExpert(int EID); //Возвращает список запросов, обрабатываемых одним экспертом
        List<ProcessingView> SelectAllProcessingList(); //Возвращает таблицу Processing
       
        #endregion
    }
}