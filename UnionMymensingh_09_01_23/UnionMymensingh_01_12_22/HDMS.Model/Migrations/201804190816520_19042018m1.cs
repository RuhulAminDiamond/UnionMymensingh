namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19042018m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreProductGroups",
                c => new
                    {
                        SPGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SPGId);
            
            CreateTable(
                "dbo.StoreProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SPGId = c.Int(nullable: false),
                        Name = c.String(),
                        Unit = c.String(),
                        PurchaseRate = c.Double(nullable: false),
                        ROL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.StoreProductGroups", t => t.SPGId, cascadeDelete: true)
                .Index(t => t.SPGId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreProducts", "SPGId", "dbo.StoreProductGroups");
            DropIndex("dbo.StoreProducts", new[] { "SPGId" });
            DropTable("dbo.StoreProducts");
            DropTable("dbo.StoreProductGroups");
        }
    }
}
