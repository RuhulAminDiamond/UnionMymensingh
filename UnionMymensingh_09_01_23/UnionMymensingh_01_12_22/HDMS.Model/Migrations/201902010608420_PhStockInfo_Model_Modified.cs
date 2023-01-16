namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhStockInfo_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhStockInfoes", "OutLetId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhStockInfoes", "OutLetId");
            AddForeignKey("dbo.PhStockInfoes", "OutLetId", "dbo.MedicineOutlets", "OutLetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhStockInfoes", "OutLetId", "dbo.MedicineOutlets");
            DropIndex("dbo.PhStockInfoes", new[] { "OutLetId" });
            DropColumn("dbo.PhStockInfoes", "OutLetId");
        }
    }
}
