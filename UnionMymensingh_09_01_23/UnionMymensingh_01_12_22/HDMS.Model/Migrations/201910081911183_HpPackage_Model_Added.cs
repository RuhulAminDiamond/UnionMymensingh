namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPackage_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpPackages",
                c => new
                    {
                        PkgId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PkgTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PkgId);
            
            CreateTable(
                "dbo.HpPkgSubItems",
                c => new
                    {
                        PkgSubItemId = c.Int(nullable: false, identity: true),
                        PkgId = c.Int(nullable: false),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PkgSubItemId)
                .ForeignKey("dbo.HpPackages", t => t.PkgId, cascadeDelete: true)
                .Index(t => t.PkgId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpPkgSubItems", "PkgId", "dbo.HpPackages");
            DropIndex("dbo.HpPkgSubItems", new[] { "PkgId" });
            DropTable("dbo.HpPkgSubItems");
            DropTable("dbo.HpPackages");
        }
    }
}
