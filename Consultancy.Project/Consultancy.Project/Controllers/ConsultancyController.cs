using Consultancy.Project.Models;
using System.Collections.Generic;
using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Consultancy.Project.Controllers
{
    public class ConsultancyController : Controller
    {
        private ConsultancyDbContext _dbContext = new ConsultancyDbContext();
                
        // GET: Consultancy
        public ActionResult Index()
        {
            return View(_dbContext.Consultancies.ToList());
        }

        // GET: Consultancy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consultancy/Create
        public ActionResult Create()
        {
            return View(new Consultancy.Project.Models.Consultancy());
        }

        // POST: Consultancy/Create
        [HttpPost]
        public ActionResult Create(Consultancy.Project.Models.Consultancy consultancy)
        {
            if(ModelState.IsValid)
            {
                consultancy.AddedDate = DateTime.Now;
                consultancy.ModifiedDate = null;
                consultancy.DeleteFlag = false;
                consultancy.DeletedDate = DateTime.Now;

                _dbContext.Consultancies.Add(consultancy);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Problem in Creating Consultancy Info");
            return View(consultancy);
        }

        // GET: Consultancy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consultancy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consultancy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consultancy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
