namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_March_02_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxInitialDatas", "RxPMId", "dbo.RxPatientMasterDatas");
            DropIndex("dbo.RxInitialDatas", new[] { "RxPMId" });
            AddColumn("dbo.RxInitialDatas", "RxVisitId", c => c.Long(nullable: false));
            CreateIndex("dbo.RxInitialDatas", "RxVisitId");
            AddForeignKey("dbo.RxInitialDatas", "RxVisitId", "dbo.RxVisitHistories", "RxVisitId", cascadeDelete: true);
            DropColumn("dbo.RxInitialDatas", "RxPMId");
            DropColumn("dbo.RxInitialDatas", "CpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxInitialDatas", "CpId", c => c.Int(nullable: false));
            AddColumn("dbo.RxInitialDatas", "RxPMId", c => c.Long(nullable: false));
            DropForeignKey("dbo.RxInitialDatas", "RxVisitId", "dbo.RxVisitHistories");
            DropIndex("dbo.RxInitialDatas", new[] { "RxVisitId" });
            DropColumn("dbo.RxInitialDatas", "RxVisitId");
            CreateIndex("dbo.RxInitialDatas", "RxPMId");
            AddForeignKey("dbo.RxInitialDatas", "RxPMId", "dbo.RxPatientMasterDatas", "RxPMId", cascadeDelete: true);
        }
    }
}
