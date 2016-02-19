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
using System.Web.Security;

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

                //_dbContext.tbl_consultancy.Add(consultancy); // This function directly called from the database located from the "context" folder
                _consultancyRepository.Insert(consultancy); // This function called from the "Repository" folder which is dependency injection of Unity in App_Start which is also registered in Global.asax
                //_dbContext.SaveChanges(); // This function can only use if direct using through database access located from "context" folder 
                return RedirectToAction("/Consultancy");
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
        public ActionResult Edit(ConsultancyModel _EditConsultancyModel)
        {
            if(ModelState.IsValid)
            {
                _EditConsultancyModel.AddedDate = DateTime.Now;
                _EditConsultancyModel.ModifiedDate = null;
                _EditConsultancyModel.DeleteFlag = false;
                _EditConsultancyModel.DeletedDate = DateTime.Now;

                //UpdateModel(_EditConsultancyModel);

                //_dbContext.Entry(_EditConsultancyModel).State = EntityState.Modified;
                //_dbContext.SaveChanges();

                _consultancyRepository.Update(_EditConsultancyModel); // This function called from the "Repository" folder which is dependency injection of Unity in App_Start which is also registered in Global.asax

                //_dbContext.tbl_consultancy.Add(_EditConsultancyModel);
                // _dbContext.tbl_consultancy.Attach(_EditConsultancyModel);
                //try
                //{
                //    _dbContext.tbl_consultancy.Attach(_EditConsultancyModel);
                //    var entry = _dbContext.Entry(_EditConsultancyModel);
                //    entry.Property(e => e.Address).IsModified = true;
                //    entry.Property(e => e.City).IsModified = true;
                //    entry.Property(e => e.Description).IsModified = true;
                //    entry.Property(e => e.Name).IsModified = true;
                //    entry.Property(e => e.State).IsModified = true;
                //    entry.Property(e => e.Status).IsModified = true;
                //    entry.Property(e => e.Latitude).IsModified = true;
                //    entry.Property(e => e.Longitude).IsModified = true;
                //   _dbContext.SaveChanges();

                //}
                //catch (Exception e)
                //{
                //    Response.Write(e.Message);
                //    Response.End();
                //}
                //var entry = _dbContext.Entry(_EditConsultancyModel);
                //entry.Property(e => e.Email).IsModified = true;
                // other changed properties

                //_dbContext.Entry(_EditConsultancyModel).State = EntityState.Modified;
                //try
                //{
                //    _dbContext.SaveChanges();

                //}
                //catch (Exception e)
                //{
                //    Response.Write(e.Message);
                //    Response.End();
                //}

                return RedirectToAction("Consultancy");
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
                //_DeleteConsultancyModel = _dbContext.tbl_consultancy.Find(id);
                //_dbContext.tbl_consultancy.Remove(_DeleteConsultancyModel);
                //_dbContext.SaveChanges();

                _consultancyRepository.Delete(id); // This function called from the "Repository" folder which is dependency injection of Unity in App_Start which is also registered in Global.asax

                return RedirectToAction("/Consultancy");
            }
            ModelState.AddModelError("", "Cannot delete, please try again");
            return View(_DeleteConsultancyModel);
        }

        [AllowAnonymous]
        public string Sample()
        {
            return "<h1>Checking with Allow Anonymous Annotation</h1>";
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}