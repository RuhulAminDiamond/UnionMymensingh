namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_Modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCompletedTestDetails",
                c => new
                    {
                        CTDId = c.Long(nullable: false, identity: true),
                        CTMId = c.Int(nullable: false),
                        TpdId = c.Int(nullable: false),
                        Parameter = c.String(),
                        ParameterValue = c.String(),
                    })
                .PrimaryKey(t => t.CTDId)
                .ForeignKey("dbo.RxCompletedTestMasters", t => t.CTMId, cascadeDelete: true)
                .Index(t => t.CTMId);
            
            CreateTable(
                "dbo.RxCompletedTestMasters",
                c => new
                    {
                        CTMId = c.Int(nullable: false, identity: true),
                        RxVisitId = c.Long(nullable: false),
                        TpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CTMId)
                .ForeignKey("dbo.RxCpPreferredTestParameterMasters", t => t.TpId, cascadeDelete: true)
                .ForeignKey("dbo.RxVisitHistories", t => t.RxVisitId, cascadeDelete: true)
                .Index(t => t.RxVisitId)
                .Index(t => t.TpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCompletedTestDetails", "CTMId", "dbo.RxCompletedTestMasters");
            DropForeignKey("dbo.RxCompletedTestMasters", "RxVisitId", "dbo.RxVisitHistories");
            DropForeignKey("dbo.RxCompletedTestMasters", "TpId", "dbo.RxCpPreferredTestParameterMasters");
            DropIndex("dbo.RxCompletedTestMasters", new[] { "TpId" });
            DropIndex("dbo.RxCompletedTestMasters", new[] { "RxVisitId" });
            DropIndex("dbo.RxCompletedTestDetails", new[] { "CTMId" });
            DropTable("dbo.RxCompletedTestMasters");
            DropTable("dbo.RxCompletedTestDetails");
        }
    }
}
