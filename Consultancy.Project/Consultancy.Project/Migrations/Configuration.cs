namespace Consultancy.Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<ConsultancyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConsultancyDbContext context)
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

            List<Consultancy> ConsultancyList = new List<Consultancy>()
            {
                new Consultancy()
                {
                    Logo            = "D:/WebSite/abc.jpg",
                    Name            = "Next Consultancy",
                    Description     = "Next Consultancy",
                    Address         = "Bagbazaar",
                    City            = "Kathmandu",
                    State           = "Kathmandu",
                    Longitude       = "36.78",
                    Latitude        = "79.34",
                    AddedDate       = DateTime.Now,
                    ModifiedDate    = null,
                    Status          = true,
                    DeleteFlag      = false,
                    DeletedDate     = DateTime.Now
                },

                new Consultancy()
                {                   
                    Logo            = "D:/WebSite/australian.jpg",
                    Name            = "Australian Consultancy",
                    Description     = "Australian Consultancy",
                    Address         = "Bagbazaar",
                    City            = "Kathmandu",
                    State           = "Kathmandu",
                    Longitude       = "36.78",
                    Latitude        = "79.34",
                    AddedDate       = DateTime.Now,
                    ModifiedDate    = null,
                    Status          = true,
                    DeleteFlag      = false,
                    DeletedDate     = DateTime.Now
                }
            };

            ConsultancyList.ForEach(c => context.Consultancies.Add(c));
        }
    }
}
