namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sept06_OPDPatien : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OPDPatientRecords", "DailyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDPatientRecords", "DailyId", c => c.Int(nullable: false));
        }
    }
}
