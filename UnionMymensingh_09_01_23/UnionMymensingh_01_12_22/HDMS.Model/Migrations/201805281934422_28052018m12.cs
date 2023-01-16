namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabinInfoes",
                c => new
                    {
                        CabinId = c.Int(nullable: false, identity: true),
                        CabinNo = c.String(),
                        Description = c.String(),
                        Rent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CabinId);
            
            CreateTable(
                "dbo.WardBedInfoes",
                c => new
                    {
                        WardBedId = c.Int(nullable: false, identity: true),
                        WardId = c.Int(nullable: false),
                        Description = c.String(),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WardBedId)
                .ForeignKey("dbo.WardInfoes", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.WardInfoes",
                c => new
                    {
                        WardId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WardBedInfoes", "WardId", "dbo.WardInfoes");
            DropIndex("dbo.WardBedInfoes", new[] { "WardId" });
            DropTable("dbo.WardInfoes");
            DropTable("dbo.WardBedInfoes");
            DropTable("dbo.CabinInfoes");
        }
    }
}
