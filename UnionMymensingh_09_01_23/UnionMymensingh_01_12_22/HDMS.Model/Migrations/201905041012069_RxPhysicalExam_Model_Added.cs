namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPhysicalExam_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxGeneralPhysicalExamItems",
                c => new
                    {
                        RxGPExamId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCode = c.String(),
                    })
                .PrimaryKey(t => t.RxGPExamId);
            
            CreateTable(
                "dbo.RxGeneralPhysicalExamSubItems",
                c => new
                    {
                        RxGPExamSubItemId = c.Int(nullable: false, identity: true),
                        RxGPExamId = c.Int(nullable: false),
                        CPId = c.Int(nullable: false),
                        SubItemName = c.String(),
                    })
                .PrimaryKey(t => t.RxGPExamSubItemId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: false)
                .ForeignKey("dbo.RxGeneralPhysicalExamItems", t => t.RxGPExamId, cascadeDelete: true)
                .Index(t => t.RxGPExamId)
                .Index(t => t.CPId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxGeneralPhysicalExamSubItems", "RxGPExamId", "dbo.RxGeneralPhysicalExamItems");
            DropForeignKey("dbo.RxGeneralPhysicalExamSubItems", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxGeneralPhysicalExamSubItems", new[] { "CPId" });
            DropIndex("dbo.RxGeneralPhysicalExamSubItems", new[] { "RxGPExamId" });
            DropTable("dbo.RxGeneralPhysicalExamSubItems");
            DropTable("dbo.RxGeneralPhysicalExamItems");
        }
    }
}
