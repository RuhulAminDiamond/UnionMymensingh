namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09052018m10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterTestGroups", "ReportOrder", c => c.Int(nullable: false));
            AddColumn("dbo.MasterTestGroups", "TokenOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MasterTestGroups", "TokenOrder");
            DropColumn("dbo.MasterTestGroups", "ReportOrder");
        }
    }
}
