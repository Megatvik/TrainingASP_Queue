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
        
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Manage
        public async Task<ActionResult> Index()
        {            
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            EditModel model = new EditModel();
            model.Email = user.Email;
            model.LastName = user.LastName;
            model.Name = user.Name;
            model.UserName = user.UserName;
            if (user != null)
            {
                return View("Index", model);
            }
            return RedirectToAction("Login", "Account");
        }

        public async Task<ActionResult> Cabinet()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);            
            if (user != null)
            {
                string role = UserManager.GetRoles(user.Id)[0].ToString();
                return RedirectToAction("Index", role);
            }
            return RedirectToAction("Login", "Account");
        }

        #region Edit

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
    
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                AuthenticationManager.SignOut();
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                EditModel model = new EditModel
                {
                    Email = user.Email,
                    Name = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName
                };

                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                user.Email = model.Email;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.UserName = model.UserName;

                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Manage");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }

        #endregion
    }
}