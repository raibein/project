namespace Consultancy.Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Consultancies", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Consultancies", "DeletedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consultancies", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Consultancies", "AddedDate", c => c.DateTime());
        }
    }
}
