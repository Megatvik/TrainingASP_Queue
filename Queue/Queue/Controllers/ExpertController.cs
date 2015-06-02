using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Queue.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Queue.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Queue.Models.Interface;
using Queue.Models.Repository;
namespace Queue.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        IExpertRepository repoExpert;
        IViewRepo repoView;
        string EID;
        public ExpertController(IExpertRepository expert, IViewRepo view)
        {
            repoExpert = expert;
            repoView = view;            
        }
        //
        // GET: /Expert/        
        public ActionResult Index()
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            return View();
        }
        public ActionResult Handle(string  QID) //Подписаться на обслуживание запроса
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            if (repoExpert.HandleQuery(EID, QID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult CancelHandle(string QID) //Отписаться от запроса
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            if (repoExpert.CancelHandleQuery(EID, QID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult AdoptClient(string QID) //Принять клиента
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            string UID;
            UID = repoExpert.AdoptClient(EID, QID);
            if (!UID.Equals("0"))
            {
                ClientView tmp = new ClientView();
                tmp.ID_client = UID;
                tmp.ID_expert = EID;
                return View("Service",tmp);
            }
            ViewBag.ErrorMessage = "Очередь пуста";
            return View("Error");
        }
        public ActionResult EndDialog(string EID, string UID)
        {            
            if(repoExpert.EndDialog(EID, UID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult SubQueue(string SubQID)
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            if (repoExpert.SendToSubQueue(EID, SubQID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        [ChildActionOnly]
        public ActionResult QueryPartial()
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            List<QueryView> list = repoView.SelectAllQuery();
            List<QueryView> processing = repoView.SelectProcessingByExpert(EID);
            foreach (QueryView query in processing)
            {
                list.RemoveAll(x => x.ID == query.ID);
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public ActionResult HandlePartial()
        {
            EID = UserManager.FindByName(User.Identity.Name).Id;
            List<QueryView> list = repoView.SelectProcessingByExpert(EID);
            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult SubQueryPartial()
        {
            List<QueryView> list = repoView.SelectAllQuery();
            return PartialView(list);
        }
	}
}