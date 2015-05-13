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

namespace Queue.Controllers
{
    public class ManageController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: Manage
        public async Task<ActionResult> Index()
        {
            
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name); // Глюк! ищет по имени а думает что по почте.
            if (user != null)
            {
                EditModel model = new EditModel { UserName = user.UserName, Email = user.Email,
                                                            Name = user.Name, LastName = user.LastName,
                                                            isBaned = user.isBaned, Role = user.Role};
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}