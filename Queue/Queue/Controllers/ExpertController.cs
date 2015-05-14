using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Queue.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        //
        // GET: /Expert/        
        public ActionResult Index()
        {
            return View();
        }
	}
}