using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consultancy.Project.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public string Sample()
        {
            return "<h1>Checking with Allow Anonymous Annotation</h1>";
        }
    }
}