using Queue.Models;
using Queue.Models.Interface;
using Queue.Models.Repository;
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
        IAdminRepository repoAdmin;
        IViewRepo repoView;
        public AdminController()
        {
            repoAdmin = new AdminRepo();
            repoView = new ViewListRepo();
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int QID)
        {
            if(repoAdmin.DeleteQuery(QID))
                return RedirectToAction("Index");
            else { return View("Error"); }
        }

        #region Edit Query
        [HttpGet]
        public ActionResult Edit()
        {
            return View("EditQuery");
        }
        [HttpPost]
        public ActionResult Edit(QueryView query)
        {
            if(repoAdmin.EditQuery(query))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        #endregion

        #region Create Query
        [HttpPost]
        public ActionResult Create(string name)
        {
            if (repoAdmin.AddQuery(name))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


        #endregion

        #region ChildActionOnly

        [ChildActionOnly]
        public ActionResult QueryPartial()
        {
            List<QueryView> list = repoView.SelectAllQuery();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult ExpertsPartial()
        {
            List<ExpertView> list = repoView.SelectAllExperts();
            return View(list);
        }
        #endregion
    }
}