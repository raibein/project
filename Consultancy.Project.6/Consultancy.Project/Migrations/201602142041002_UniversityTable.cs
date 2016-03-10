namespace Consultancy.Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniversityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UniversityModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Logo = c.String(),
                    Name = c.String(),
                    Description = c.String(),
                    Address = c.String(),
                    City = c.String(),
                    State = c.String(),
                    AddedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(),
                    Status = c.Boolean(nullable: false),
                    DeleteFlag = c.Boolean(nullable: false),
                    DeletedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.UniversityModels");
        }
    }
}
