namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhStockTransferRecord_Model_Modified_Aug20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhStockTransferRecords", "RequisitionNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhStockTransferRecords", "RequisitionNo");
        }
    }
}
