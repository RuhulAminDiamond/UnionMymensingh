namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28062018m2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "ReportId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "ReportId", c => c.Int(nullable: false));
        }
    }
}
