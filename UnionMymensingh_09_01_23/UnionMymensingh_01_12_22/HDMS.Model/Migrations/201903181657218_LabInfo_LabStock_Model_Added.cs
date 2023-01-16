namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LabInfo_LabStock_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabInfoes",
                c => new
                    {
                        LabId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InChargeName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.LabId);
            
            CreateTable(
                "dbo.LabStockInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Stock = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LabInfoes", t => t.LabId, cascadeDelete: true)
                .ForeignKey("dbo.StoreProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.LabId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabStockInfoes", "ProductId", "dbo.StoreProductInfoes");
            DropForeignKey("dbo.LabStockInfoes", "LabId", "dbo.LabInfoes");
            DropIndex("dbo.LabStockInfoes", new[] { "ProductId" });
            DropIndex("dbo.LabStockInfoes", new[] { "LabId" });
            DropTable("dbo.LabStockInfoes");
            DropTable("dbo.LabInfoes");
        }
    }
}
