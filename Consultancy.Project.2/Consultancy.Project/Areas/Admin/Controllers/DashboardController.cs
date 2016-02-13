using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Consultancy.Project.Areas.Admin.Models;
using Consultancy.Project.context;
using Consultancy.Project.Repository;

namespace Consultancy.Project.Areas.Admin.Controllers
{    

    [Authorize]
    public class DashboardController : Controller
    {
        private IConsultancyRepository _consultancyRepository;
        private AppDbContext _dbContext = new AppDbContext();

        public DashboardController(IConsultancyRepository _consultancyRepository)
        {
            this._consultancyRepository = _consultancyRepository;
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Dashboard/Consultancy
        public ActionResult Consultancy()
        {
            //return View(_dbContext.tbl_consultancy.ToList()); // This function directly called from the database located from the "context" folder
            return View(_consultancyRepository.GetAll()); // This function called from the "Repository" folder which is dependency injection of Unity in App_Start which is also registered in Global.asax
        }

        // GET: Admin/Dashboar/Consultancy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Dashboar/Consultancy/Create
        public ActionResult Create()
        {
            return View(new ConsultancyModel());
        }

        // POST: Admin/Dashboar/Consultancy/Create
        [HttpPost]
        public ActionResult Create(ConsultancyModel consultancy)
        {
            if (ModelState.IsValid)
            {
                consultancy.AddedDate = DateTime.Now;
                consultancy.ModifiedDate = null;
                consultancy.DeleteFlag = false;
                consultancy.DeletedDate = DateTime.Now;

                _dbContext.tbl_consultancy.Add(consultancy);
                _dbContext.SaveChanges();
                return RedirectToAction("Dashboard/Consultancy");
            }
            ModelState.AddModelError("", "Problem occured for Adding Consultancy Info");
            return View(consultancy);
        }

        // GET: Admin/Dashboar/Consultancy/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if(id == 0)
            {
                return RedirectToAction("Consultancy");
            }

            ConsultancyModel _consultancyModel = _dbContext.tbl_consultancy.Find(id);
            if(_consultancyModel == null)
            {
                return RedirectToAction("Consultancy");
            }

            return View(_consultancyModel);
        }

        // POST: Admin/Dashboar/Consultancy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ConsultancyModel _EditConsultancyModel)
        {
            if(ModelState.IsValid)
            {
                _EditConsultancyModel.ModifiedDate = DateTime.Now;
                _EditConsultancyModel.DeleteFlag = false;
                _EditConsultancyModel.DeletedDate = DateTime.Now;

                _dbContext.tbl_consultancy.Add(_EditConsultancyModel);
                _dbContext.SaveChanges();
                return RedirectToAction("Dashboard/Consultancy");
            }
            ModelState.AddModelError("", "Cannot edit, please try again");
            return View(_EditConsultancyModel);
        }

        // GET: Admin/Dashboar/Consultancy/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Consultancy");
            }

            ConsultancyModel _consultancyModel = _dbContext.tbl_consultancy.Find(id);
            if (_consultancyModel == null)
            {
                return RedirectToAction("Consultancy");
            }

            return View(_consultancyModel);
        }

        // POST: Admin/Dashboar/Consultancy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ConsultancyModel _DeleteConsultancyModel)
        {
            if (ModelState.IsValid)
            {
                _DeleteConsultancyModel.ModifiedDate = DateTime.Now;
                _DeleteConsultancyModel.DeleteFlag = true;
                _DeleteConsultancyModel.DeletedDate = DateTime.Now;

                _dbContext.tbl_consultancy.Add(_DeleteConsultancyModel);
                _dbContext.SaveChanges();
                return RedirectToAction("Dashboard/Consultancy");
            }
            ModelState.AddModelError("", "Cannot delete, please try again");
            return View(_DeleteConsultancyModel);
        }

        [AllowAnonymous]
        public string Sample()
        {
            return "<h1>Checking with Allow Anonymous Annotation</h1>";
        }
    }
}