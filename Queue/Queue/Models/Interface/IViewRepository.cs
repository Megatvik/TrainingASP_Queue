﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Models.Interface
{
    interface IViewRepository
    {
        List<QueryView> SelectAllQuery(); // Возвращает список всех запросов 
        List<ExpertView> SelectAllExperts(); //Возвращает список всех экспертов
        List<QueryView> SelectProcessingByExpert(int EID); //Возвращает список запросов, обрабатываемых одним экспертом
        List<ProcessingView> SelectAllProcessingList(); //Возвращает таблицу Processing
        QueueView SelectQueueInfo(int UID); //Возвращает информацию о позиции в очереди
    }
}
