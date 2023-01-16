namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class July09_PhStockTransferModel_Added_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhStockTransferRecordDetails", "Qty", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhStockTransferRecordDetails", "Qty");
        }
    }
}
