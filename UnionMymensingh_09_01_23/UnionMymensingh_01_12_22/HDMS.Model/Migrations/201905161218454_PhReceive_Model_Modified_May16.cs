namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceive_Model_Modified_May16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceives", "VatTk", c => c.Double(nullable: false));
            AddColumn("dbo.PhReceives", "GtotalTk", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceives", "GtotalTk");
            DropColumn("dbo.PhReceives", "VatTk");
        }
    }
}
