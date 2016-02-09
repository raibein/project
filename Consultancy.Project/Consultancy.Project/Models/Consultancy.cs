using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Consultancy.Project.Models
{
    public class Consultancy
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DeletedDate { get; set; }
    }

    public class ConsultancyDbContext:DbContext
    {
        public ConsultancyDbContext() : base("DefaultConnection")
        {

        }
        public virtual DbSet<Consultancy> Consultancies { get; set; }
    }
}