namespace Consultancy.Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    using Consultancy.Project.context;
    using Areas.Admin.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<UniversityModel> UniversityList = new List<UniversityModel>()
            {
                new UniversityModel()
                {
                    Logo            = "D:/WebSite/howard.jpg",
                    Name            = "Howard University",
                    Description     = "Howard University is the best university in U.S",
                    Address         = "New York",
                    City            = "New York",
                    State           = "New York",
                    AddedDate       = DateTime.Now,
                    ModifiedDate    = null,
                    Status          = true,
                    DeleteFlag      = false,
                    DeletedDate     = DateTime.Now
                },

                new UniversityModel()
                {
                    Logo            = "D:/WebSite/dbu.jpg",
                    Name            = "Dallas Bapti University",
                    Description     = "DBU University is located in Dallas for international students.",
                    Address         = "Dallas",
                    City            = "Dallas",
                    State           = "Dallas",
                    AddedDate       = DateTime.Now,
                    ModifiedDate    = null,
                    Status          = true,
                    DeleteFlag      = false,
                    DeletedDate     = DateTime.Now
                }
            };

            UniversityList.ForEach(c=>context.tbl_university.AddOrUpdate(c));
        }
    }
}
