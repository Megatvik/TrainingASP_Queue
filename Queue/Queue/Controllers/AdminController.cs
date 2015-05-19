using Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Queue.Controllers
{
    [Authorize (Roles="Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            List<QueryView> list = new List<QueryView>() 
            {
                new QueryView(){NameQuery="123", ExpertsCount=1, QueueCount=0, SubQueueCount=0},
                new QueryView(){NameQuery="qwe", ExpertsCount=1, QueueCount=0, SubQueueCount=0},
                new QueryView(){NameQuery="asd", ExpertsCount=1, QueueCount=0, SubQueueCount=0}
            };
            return View(list);
        }
	}
}