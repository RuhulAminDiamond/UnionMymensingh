namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_Model_Modified_Jun05_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "DoseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "DoseId");
        }
    }
}
