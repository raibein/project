using Consultancy.Project.Areas.Admin.Models;
using Consultancy.Project.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultancy.Project.Repository
{
    public interface IConsultancyRepository
    {
        List<ConsultancyModel> GetAll();
    }
    public class ConsultancyRepository : IConsultancyRepository
    {
        private AppDbContext _dbContext = new AppDbContext();

        public List<ConsultancyModel> GetAll()
        {
            return _dbContext.tbl_consultancy.ToList();
        }
    }
}