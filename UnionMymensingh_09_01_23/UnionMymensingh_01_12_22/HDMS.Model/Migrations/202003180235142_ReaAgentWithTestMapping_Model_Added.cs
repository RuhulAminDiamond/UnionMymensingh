namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaAgentWithTestMapping_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReagentWithTestMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreProductInfoes", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TestItems", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReagentWithTestMappings", "TestId", "dbo.TestItems");
            DropForeignKey("dbo.ReagentWithTestMappings", "ProductId", "dbo.StoreProductInfoes");
            DropIndex("dbo.ReagentWithTestMappings", new[] { "ProductId" });
            DropIndex("dbo.ReagentWithTestMappings", new[] { "TestId" });
            DropTable("dbo.ReagentWithTestMappings");
        }
    }
}
