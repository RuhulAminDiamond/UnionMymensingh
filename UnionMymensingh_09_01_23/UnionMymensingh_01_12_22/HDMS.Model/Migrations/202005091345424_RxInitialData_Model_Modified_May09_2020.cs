namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_May09_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "CCDuration", c => c.String());
            AddColumn("dbo.RxInitialDatas", "CCDurationUnit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxInitialDatas", "CCDurationUnit");
            DropColumn("dbo.RxInitialDatas", "CCDuration");
        }
    }
}
