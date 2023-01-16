namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_Feb24_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "PresentHistory", c => c.String());
            DropColumn("dbo.RxInitialDatas", "Additional");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxInitialDatas", "Additional", c => c.String());
            DropColumn("dbo.RxInitialDatas", "PresentHistory");
        }
    }
}
