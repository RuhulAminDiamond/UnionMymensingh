namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_Model_Modified_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "PkgUnit", c => c.String());
            AddColumn("dbo.PhProductInfoes", "QtyPerBox", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "QtyPerBox");
            DropColumn("dbo.PhProductInfoes", "PkgUnit");
        }
    }
}
