namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_Modofied_Feb23_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxPatientMasterDatas", "RxInitDId", "dbo.RxInitialDatas");
            DropIndex("dbo.RxPatientMasterDatas", new[] { "RxInitDId" });
            AddColumn("dbo.RxVisitHistories", "AgeYear", c => c.String());
            AddColumn("dbo.RxVisitHistories", "AgeMonth", c => c.String());
            AddColumn("dbo.RxVisitHistories", "AgeDay", c => c.String());
            DropColumn("dbo.RxPatientMasterDatas", "RxInitDId");
            DropColumn("dbo.RxPatientMasterDatas", "AgeYear");
            DropColumn("dbo.RxPatientMasterDatas", "AgeMonth");
            DropColumn("dbo.RxPatientMasterDatas", "AgeDay");
            DropColumn("dbo.RxPatientMasterDatas", "IsServiceDelivered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientMasterDatas", "IsServiceDelivered", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPatientMasterDatas", "AgeDay", c => c.String());
            AddColumn("dbo.RxPatientMasterDatas", "AgeMonth", c => c.String());
            AddColumn("dbo.RxPatientMasterDatas", "AgeYear", c => c.String());
            AddColumn("dbo.RxPatientMasterDatas", "RxInitDId", c => c.Long(nullable: false));
            DropColumn("dbo.RxVisitHistories", "AgeDay");
            DropColumn("dbo.RxVisitHistories", "AgeMonth");
            DropColumn("dbo.RxVisitHistories", "AgeYear");
            CreateIndex("dbo.RxPatientMasterDatas", "RxInitDId");
            AddForeignKey("dbo.RxPatientMasterDatas", "RxInitDId", "dbo.RxInitialDatas", "RxInitDId", cascadeDelete: true);
        }
    }
}
