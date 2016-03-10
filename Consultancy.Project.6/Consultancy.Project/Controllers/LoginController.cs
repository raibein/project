using Consultancy.Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Consultancy.Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new Login());
        }

        [HttpPost]
        // POST: Login
        public ActionResult Index(Login login, string ReturnUrl="")
        {
            if(ModelState.IsValid)
            {
                if(Membership.ValidateUser(login.UserName, login.Password))
                {
                    Consultancy.Project.Models.User user = (Consultancy.Project.Models.User)Session["user"];

                    if(user.Status)
                    {
                        FormsAuthentication.SetAuthCookie(login.UserName, false);

                        return RedirectToAction("Index", "Admin/Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your account is not activated yet");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }            
            return View(new Login());
        }
    }
}