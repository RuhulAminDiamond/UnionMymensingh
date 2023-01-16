namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientHistoryItem_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientHistoryItems", "ItemCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxPatientHistoryItems", "ItemCode");
        }
    }
}
