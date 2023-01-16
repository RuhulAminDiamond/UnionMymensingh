namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ph_Model_Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhLotInfoes",
                c => new
                    {
                        LotNo = c.Long(nullable: false, identity: true),
                        BatchNo = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LotNo);
            
            CreateIndex("dbo.PhStockInfoes", "LotNo");
            CreateIndex("dbo.PhStockInfoes", "ProductId");
            AddForeignKey("dbo.PhStockInfoes", "LotNo", "dbo.PhLotInfoes", "LotNo", cascadeDelete: true);
            AddForeignKey("dbo.PhStockInfoes", "ProductId", "dbo.PhProductInfoes", "ProductId", cascadeDelete: true);
            DropColumn("dbo.PhStockInfoes", "BatchNo");
            DropColumn("dbo.PhStockInfoes", "ExpireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhStockInfoes", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhStockInfoes", "BatchNo", c => c.String());
            DropForeignKey("dbo.PhStockInfoes", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.PhStockInfoes", "LotNo", "dbo.PhLotInfoes");
            DropIndex("dbo.PhStockInfoes", new[] { "ProductId" });
            DropIndex("dbo.PhStockInfoes", new[] { "LotNo" });
            DropTable("dbo.PhLotInfoes");
        }
    }
}
