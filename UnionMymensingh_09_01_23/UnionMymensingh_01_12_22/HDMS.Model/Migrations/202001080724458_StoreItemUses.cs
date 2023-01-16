namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreItemUses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreItemUsesMasterDetails",
                c => new
                    {
                        StMDId = c.Long(nullable: false, identity: true),
                        StMId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StMDId)
                .ForeignKey("dbo.StoreItemUsesMasters", t => t.StMId, cascadeDelete: true)
                .ForeignKey("dbo.StoreProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.StMId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreItemUsesMasters",
                c => new
                    {
                        StMId = c.Long(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        BillNo = c.Long(nullable: false),
                        UDate = c.DateTime(nullable: false),
                        UTime = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StMId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreItemUsesMasterDetails", "ProductId", "dbo.StoreProductInfoes");
            DropForeignKey("dbo.StoreItemUsesMasterDetails", "StMId", "dbo.StoreItemUsesMasters");
            DropIndex("dbo.StoreItemUsesMasterDetails", new[] { "ProductId" });
            DropIndex("dbo.StoreItemUsesMasterDetails", new[] { "StMId" });
            DropTable("dbo.StoreItemUsesMasters");
            DropTable("dbo.StoreItemUsesMasterDetails");
        }
    }
}
