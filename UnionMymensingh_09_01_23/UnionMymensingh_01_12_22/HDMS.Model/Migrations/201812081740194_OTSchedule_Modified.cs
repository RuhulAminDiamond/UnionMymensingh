namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTSchedule_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OTSchedules", "OTName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OTSchedules", "OTName");
        }
    }
}
