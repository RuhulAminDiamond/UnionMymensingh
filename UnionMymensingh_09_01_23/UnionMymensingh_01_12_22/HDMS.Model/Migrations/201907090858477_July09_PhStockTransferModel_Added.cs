namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class July09_PhStockTransferModel_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhStockTransferRecordDetails",
                c => new
                    {
                        STDId = c.Long(nullable: false, identity: true),
                        StTId = c.Long(nullable: false),
                        LotNo = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.STDId)
                .ForeignKey("dbo.PhLotInfoes", t => t.LotNo, cascadeDelete: true)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PhStockTransferRecords", t => t.StTId, cascadeDelete: true)
                .Index(t => t.StTId)
                .Index(t => t.LotNo)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PhStockTransferRecords",
                c => new
                    {
                        StTId = c.Long(nullable: false, identity: true),
                        TDate = c.DateTime(nullable: false),
                        TTime = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.StTId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhStockTransferRecordDetails", "StTId", "dbo.PhStockTransferRecords");
            DropForeignKey("dbo.PhStockTransferRecordDetails", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.PhStockTransferRecordDetails", "LotNo", "dbo.PhLotInfoes");
            DropIndex("dbo.PhStockTransferRecordDetails", new[] { "ProductId" });
            DropIndex("dbo.PhStockTransferRecordDetails", new[] { "LotNo" });
            DropIndex("dbo.PhStockTransferRecordDetails", new[] { "StTId" });
            DropTable("dbo.PhStockTransferRecords");
            DropTable("dbo.PhStockTransferRecordDetails");
        }
    }
}
