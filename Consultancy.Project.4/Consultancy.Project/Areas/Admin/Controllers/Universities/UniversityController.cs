using Consultancy.Project.Areas.Admin.Models;
using Consultancy.Project.context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Consultancy.Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Security;

namespace Consultancy.Project.Areas.Admin.Controllers.Universities
{
    [Authorize]
    public class UniversityController : Controller
    {
        //private IConsultancyRepository _consultancyRepository;
        private AppDbContext _dbContext = new AppDbContext();

        // GET: Admin/University
        public ActionResult Index()
        {
            return View(_dbContext.tbl_university.ToList()); // This function directly called from the database located from the "context" folder
        }

        // GET: Admin/University/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/University/Create
        public ActionResult Create()
        {
            return View(new UniversityModel());
        }

        // POST: Admin/University/Create
        [HttpPost]
        public ActionResult Create(UniversityModel _universityModel)
        {
            if(ModelState.IsValid)
            {
                _universityModel.AddedDate = DateTime.Now;
                _universityModel.ModifiedDate = null;
                _universityModel.DeleteFlag = false;
                _universityModel.DeletedDate = DateTime.Now;

                _dbContext.tbl_university.Add(_universityModel);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
                return View(_universityModel);
        }

        // GET: Admin/University/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("University");
            }

            UniversityModel _uniModel = _dbContext.tbl_university.Find(id);
            if (_uniModel == null)
            {
                return RedirectToAction("University");
            }

            return View(_uniModel);
        }

        // POST: Admin/University/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UniversityModel _uniModel)
        {
            if (ModelState.IsValid)
            {
                _uniModel.AddedDate = DateTime.Now;
                _uniModel.ModifiedDate = null;
                _uniModel.DeleteFlag = false;
                _uniModel.DeletedDate = DateTime.Now;

                //UpdateModel(_EditConsultancyModel);
                _dbContext.Entry(_uniModel).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("University");
            }
            ModelState.AddModelError("", "Cannot edit university, please try again");
            return View(_uniModel);
        }

        // GET: Admin/University/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("University");
            }

            UniversityModel _universityModel = _dbContext.tbl_university.Find(id);
            if (_universityModel == null)
            {
                return RedirectToAction("University");
            }

            return View(_universityModel);
        }

        // POST: Admin/University/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UniversityModel _delUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _delUniversityModel = _dbContext.tbl_university.Find(id);
                _dbContext.tbl_university.Remove(_delUniversityModel);
                _dbContext.SaveChanges();
                return RedirectToAction("/University");
            }
            ModelState.AddModelError("", "Cannot delete university info, please try again");
            return View(_delUniversityModel);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
