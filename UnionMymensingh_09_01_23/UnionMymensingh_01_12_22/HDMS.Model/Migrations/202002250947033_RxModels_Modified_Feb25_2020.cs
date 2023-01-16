namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModels_Modified_Feb25_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "RxPMId", c => c.Long(nullable: false));
            AddColumn("dbo.RxInitialDatas", "RxInitDDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RxInitialDatas", "RxInitDTime", c => c.String());
            CreateIndex("dbo.RxInitialDatas", "RxPMId");
            AddForeignKey("dbo.RxInitialDatas", "RxPMId", "dbo.RxPatientMasterDatas", "RxPMId", cascadeDelete: true);
            DropColumn("dbo.RxInitialDatas", "RegNo");
            DropColumn("dbo.RxInitialDatas", "RxDate");
            DropColumn("dbo.RxInitialDatas", "RxTime");
            DropColumn("dbo.RxInitialDatas", "SpecilaAlert");
            DropColumn("dbo.RxInitialDatas", "Confidential");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxInitialDatas", "Confidential", c => c.String());
            AddColumn("dbo.RxInitialDatas", "SpecilaAlert", c => c.String());
            AddColumn("dbo.RxInitialDatas", "RxTime", c => c.String());
            AddColumn("dbo.RxInitialDatas", "RxDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RxInitialDatas", "RegNo", c => c.Long(nullable: false));
            DropForeignKey("dbo.RxInitialDatas", "RxPMId", "dbo.RxPatientMasterDatas");
            DropIndex("dbo.RxInitialDatas", new[] { "RxPMId" });
            DropColumn("dbo.RxInitialDatas", "RxInitDTime");
            DropColumn("dbo.RxInitialDatas", "RxInitDDate");
            DropColumn("dbo.RxInitialDatas", "RxPMId");
        }
    }
}
