using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queue.Models.Interface;
using Queue.Models.Repository;
using Queue.Models;

namespace Queue.Controllers
{
    public class ClientController : Controller
    {
        IClientRepository ClientRepo;
        IViewRepo ViewRepo;
        int UID;
        public ClientController()
        {
            ClientRepo = new ClientRepoTest();
            ViewRepo = new ViewListRepoTest();
            UID = 1;
        }
        // GET: Client
        public ActionResult Index()
        {
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
            QueueView queue = ViewRepo.SelectQueueInfo(UID);
            return View(queue);
        }
    }
}