namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rx_Ph_Hospital_Model_Modified_Jun05_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxDrugs", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropIndex("dbo.RxDrugs", new[] { "CPPMId" });
            CreateTable(
                "dbo.RxDosages",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        DoseEnLong = c.String(),
                        DoseBnLong = c.String(),
                        DoseEnShort = c.String(),
                        DoseBnShort = c.String(),
                        ShortKey = c.String(),
                        EMRInterPretId = c.Int(nullable: false),
                        Createdby = c.String(),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.DoseId);
            
            AddColumn("dbo.PhProductInfoes", "BeforeAfterEn", c => c.String());
            AddColumn("dbo.PhProductInfoes", "BeforeAfterBn", c => c.String());
            AddColumn("dbo.PhProductInfoes", "Duration", c => c.String());
            AddColumn("dbo.PhProductInfoes", "DurationUnit", c => c.String());
            AddColumn("dbo.HpPatientAccomodationInfoes", "Modifiedby", c => c.String());
            AddColumn("dbo.HpPatientAccomodationInfoes", "Modifiydate", c => c.DateTime());
            AddColumn("dbo.HpPatientAccomodationInfoes", "ModifyTime", c => c.String());
            AddColumn("dbo.RxDrugs", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.RxDrugs", "IsPickedFromPDb", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxTests", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.RxTests", "IsPickedFromPDb", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxTests", "IsPickedFromPDb");
            DropColumn("dbo.RxTests", "TestId");
            DropColumn("dbo.RxDrugs", "IsPickedFromPDb");
            DropColumn("dbo.RxDrugs", "ProductId");
            DropColumn("dbo.HpPatientAccomodationInfoes", "ModifyTime");
            DropColumn("dbo.HpPatientAccomodationInfoes", "Modifiydate");
            DropColumn("dbo.HpPatientAccomodationInfoes", "Modifiedby");
            DropColumn("dbo.PhProductInfoes", "DurationUnit");
            DropColumn("dbo.PhProductInfoes", "Duration");
            DropColumn("dbo.PhProductInfoes", "BeforeAfterBn");
            DropColumn("dbo.PhProductInfoes", "BeforeAfterEn");
            DropTable("dbo.RxDosages");
            CreateIndex("dbo.RxDrugs", "CPPMId");
            AddForeignKey("dbo.RxDrugs", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
        }
    }
}
