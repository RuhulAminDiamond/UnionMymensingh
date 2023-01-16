namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacuType_VacuWithTest_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VacuTypes",
                c => new
                    {
                        VTId = c.Int(nullable: false, identity: true),
                        VType = c.String(),
                    })
                .PrimaryKey(t => t.VTId);
            
            CreateTable(
                "dbo.VacuWithTestSettings",
                c => new
                    {
                        VSId = c.Int(nullable: false, identity: true),
                        VTId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VSId)
                .ForeignKey("dbo.TestItems", t => t.TestId, cascadeDelete: true)
                .ForeignKey("dbo.VacuTypes", t => t.VTId, cascadeDelete: true)
                .Index(t => t.VTId)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacuWithTestSettings", "VTId", "dbo.VacuTypes");
            DropForeignKey("dbo.VacuWithTestSettings", "TestId", "dbo.TestItems");
            DropIndex("dbo.VacuWithTestSettings", new[] { "TestId" });
            DropIndex("dbo.VacuWithTestSettings", new[] { "VTId" });
            DropTable("dbo.VacuWithTestSettings");
            DropTable("dbo.VacuTypes");
        }
    }
}
