using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queue.Models;
using Queue.Models.Interface;
using Queue.Models.Repository;
namespace Queue.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        IExpertRepository repoExpert;
        IViewRepo repoView;
        int EID;
        public ExpertController()
        {
            repoExpert = new ExpertRepoTest();
            repoView = new ViewListRepoTest();
            EID = 0;
        }
        //
        // GET: /Expert/        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Handle(int  QID) //Подписаться на обслуживание запроса
        {
            if (repoExpert.HandleQuery(EID, QID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult CancelHandle(int QID) //Отписаться от запроса
        {
            if (repoExpert.CancelHandleQuery(EID, QID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult AdoptClient(int QID) //Принять клиента
        {
            if (repoExpert.AdoptClient(EID,QID) != 0)
            {
                return RedirectToAction("Index"); // Сдесь должна быть чат-комната
            }
            return View("Error");
        }

        [ChildActionOnly]
        public ActionResult QueryPartial()
        {
            List<QueryView> list = repoView.SelectAllQuery();
            return PartialView(list);
        }

        [ChildActionOnly]
        public ActionResult HandlePartial()
        {
            List<QueryView> list = repoView.SelectProcessingByExpert(EID);
            return PartialView(list);
        }
	}
}