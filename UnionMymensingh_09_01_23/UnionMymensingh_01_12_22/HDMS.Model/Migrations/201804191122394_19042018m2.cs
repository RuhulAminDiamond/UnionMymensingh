namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19042018m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreProductMasterGroups",
                c => new
                    {
                        MGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MGId);
            
            CreateTable(
                "dbo.StoreProductSubGroups",
                c => new
                    {
                        SPGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MGId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SPGId)
                .ForeignKey("dbo.StoreProductMasterGroups", t => t.MGId, cascadeDelete: true)
                .Index(t => t.MGId);
            
            DropTable("dbo.StoreProductGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StoreProductGroups",
                c => new
                    {
                        SPGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SPGId);
            
            DropForeignKey("dbo.StoreProductSubGroups", "MGId", "dbo.StoreProductMasterGroups");
            DropIndex("dbo.StoreProductSubGroups", new[] { "MGId" });
            DropTable("dbo.StoreProductSubGroups");
            DropTable("dbo.StoreProductMasterGroups");
        }
    }
}
