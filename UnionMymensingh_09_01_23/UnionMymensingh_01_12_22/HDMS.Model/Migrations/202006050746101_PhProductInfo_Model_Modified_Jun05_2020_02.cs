namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_Model_Modified_Jun05_2020_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "RxFriendlyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "RxFriendlyName");
        }
    }
}
