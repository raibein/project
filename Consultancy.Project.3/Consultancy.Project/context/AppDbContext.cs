using Consultancy.Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Consultancy.Project.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
        public virtual DbSet<ConsultancyModel> tbl_consultancy { get; set; }
    }
}