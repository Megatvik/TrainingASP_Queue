using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queue.Models.Interface;
using Queue.Models.Repository;
using Queue.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.SqlClient;

namespace Queue.Controllers
{
    public class ClientController : Controller
    {

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        IClientRepository ClientRepo;
        IViewRepo ViewRepo;
        string UID;
        public ClientController()
        {
            ClientRepo = new ClientRepo();
            ViewRepo = new ViewListRepo();
        }
        // GET: Client
        public ActionResult Index()
        {
            UID = UserManager.FindByName(User.Identity.Name).Id;
            ViewBag.IsInQueue = ClientRepo.IsInQueue(UID);
            return View();
        }

        [ChildActionOnly]
        public ActionResult QueryPartial()
        {
            List<QueryView> list = ViewRepo.SelectAllQuery();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult QueueInfo()
        {
            UID = UserManager.FindByName(User.Identity.Name).Id;
            QueueView queue = ViewRepo.SelectQueueInfo(UID);
            return View(queue);
        }
        public ActionResult EnterQueue(string QID)
        {
            UID = UserManager.FindByName(User.Identity.Name).Id;
            if(ClientRepo.EnterQueue(UID,QID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult LeaveQueue()
        {
            UID = UserManager.FindByName(User.Identity.Name).Id;
            if (ClientRepo.LeaveQueue(UID))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}