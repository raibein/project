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
using System.IO;
using PagedList;

namespace Consultancy.Project.Areas.Admin.Controllers
{    

    [Authorize]
    public class DashboardController : Controller
    {
        private IConsultancyRepository _consultancyRepository;
        private AppDbContext _dbContext = new AppDbContext();
        private object Id;

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
        public ActionResult Consultancy(int? page)
        {            
            //var students = from s in _dbContext.tbl_consultancy select s;

            var consultancyVar = _consultancyRepository.GetAll();

            //return View(_dbContext.tbl_consultancy.ToList()); // This function directly called from the database located from the "context" folder
            //return View(_consultancyRepository.GetAll()); // This function called from the "Repository" folder which is dependency injection of Unity in App_Start which is also registered in Global.asax

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(consultancyVar.ToPagedList(pageNumber, pageSize));
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

                string extension = System.IO.Path.GetDirectoryName("~/Areas/Admin/Images/");
                string targetFolder = HttpContext.Server.MapPath("~/Areas/Admin/Images/");
                string targetPath = Path.Combine(targetFolder, Request.Files[0].FileName);
                

                if (Request.Files[0].ContentLength > 0)
                {
                    
                    //string path1 = Server.MapPath("~/Admin/Images/" + Request.Files[0].FileName);                    
                    //string path = HttpContext.Server.MapPath("~/Admin/Images/");
                    //string filename = Path.GetFileName(Request.Files[0].FileName);

                    Console.Write(extension);
                    Console.Write(targetPath);
                    Console.Write(targetFolder);
                                        
                    Request.Files[0].SaveAs(targetPath);

                    ViewData["Success"] = "Successfully inserted into your data";
                }
                else
                {
                    ViewData["Success"] = "Upload Failed.";
                }
                //return View();
                
                consultancy.Logo = Request.Files[0].FileName;

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
        public ActionResult Edit(int id, ConsultancyModel _EditConsultancyModel)
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

                _EditConsultancyModel = _dbContext.tbl_consultancy.Find(id);

                if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Images/") + _EditConsultancyModel.Logo))
                {
                    System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Images/") + _EditConsultancyModel.Logo);
                    
                    string targetFolder = HttpContext.Server.MapPath("~/Areas/Admin/Images/");
                    string targetPath = Path.Combine(targetFolder, Request.Files[0].FileName);

                    Request.Files[0].SaveAs(targetPath);
                }

                _EditConsultancyModel.Logo = Request.Files[0].FileName;

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
                _DeleteConsultancyModel = _dbContext.tbl_consultancy.Find(id);
                //_dbContext.tbl_consultancy.Remove(_DeleteConsultancyModel);
                //_dbContext.SaveChanges();

                System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Images/") + _DeleteConsultancyModel.Logo);
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
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}