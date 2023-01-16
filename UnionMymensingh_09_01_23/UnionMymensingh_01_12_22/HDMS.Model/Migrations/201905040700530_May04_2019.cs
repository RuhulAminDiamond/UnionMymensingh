namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class May04_2019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxMedicineTemplateDetails", "ProductId", "dbo.PhProductInfoes");
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "ProductId" });
            CreateTable(
                "dbo.CPPreferredMedicines",
                c => new
                    {
                        CPPMId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CPPMId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CPId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.RxMedicineTemplateDetails", "CPPMId", c => c.Long(nullable: false));
            AddColumn("dbo.RxPatientHistorySubItems", "CPId", c => c.Int(nullable: false));
            CreateIndex("dbo.RxMedicineTemplateDetails", "CPPMId");
            CreateIndex("dbo.RxPatientHistorySubItems", "CPId");
           // AddForeignKey("dbo.RxMedicineTemplateDetails", "CPPMId", "dbo.CPPreferredMedicines", "CPPMId", cascadeDelete: true);
            AddForeignKey("dbo.RxPatientHistorySubItems", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            DropColumn("dbo.RxMedicineTemplateDetails", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxMedicineTemplateDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RxPatientHistorySubItems", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "CPPMId", "dbo.CPPreferredMedicines");
            DropForeignKey("dbo.CPPreferredMedicines", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.CPPreferredMedicines", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxPatientHistorySubItems", new[] { "CPId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.CPPreferredMedicines", new[] { "ProductId" });
            DropIndex("dbo.CPPreferredMedicines", new[] { "CPId" });
            DropColumn("dbo.RxPatientHistorySubItems", "CPId");
            DropColumn("dbo.RxMedicineTemplateDetails", "CPPMId");
            DropTable("dbo.CPPreferredMedicines");
            CreateIndex("dbo.RxMedicineTemplateDetails", "ProductId");
            AddForeignKey("dbo.RxMedicineTemplateDetails", "ProductId", "dbo.PhProductInfoes", "ProductId", cascadeDelete: true);
        }
    }
}
