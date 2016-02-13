namespace Consultancy.Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialConsultancy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsultancyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
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
            DropTable("dbo.ConsultancyModels");
        }
    }
}
