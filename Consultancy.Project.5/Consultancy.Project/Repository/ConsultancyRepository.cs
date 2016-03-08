using Consultancy.Project.Areas.Admin.Models;
using Consultancy.Project.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Consultancy.Project.Repository
{

    public interface IConsultancyRepository : IGenericRepository<ConsultancyModel>
    {

    }
    public class ConsultancyRepository : IConsultancyRepository
    {
        private AppDbContext _dbContext = new AppDbContext();

        public void Delete(int id)
        {
            ConsultancyModel _consultancyModel = _dbContext.tbl_consultancy.Find(id);
            _dbContext.tbl_consultancy.Remove(_consultancyModel);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ConsultancyModel> GetAll()
        {
            return _dbContext.tbl_consultancy.ToList();
        }

        public ConsultancyModel GetById(int id)
        {
            return _dbContext.tbl_consultancy.Find(id);
        }

        public void Insert(ConsultancyModel t)
        {
            _dbContext.tbl_consultancy.Add(t);
            _dbContext.SaveChanges();
        }

        public List<ConsultancyModel> Search(Expression<Func<ConsultancyModel>> t)
        {
            throw new NotImplementedException();
        }

        public void Update(ConsultancyModel t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}