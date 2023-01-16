namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DichargeModule_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DischargeCertificateDetails",
                c => new
                    {
                        DischargeDetailId = c.Long(nullable: false, identity: true),
                        DischargeId = c.Long(nullable: false),
                        DescriptionTitle = c.String(),
                        Description = c.String(),
                        DescriptionType = c.String(),
                    })
                .PrimaryKey(t => t.DischargeDetailId)
                .ForeignKey("dbo.DischargeCertificateMasters", t => t.DischargeId, cascadeDelete: true)
                .Index(t => t.DischargeId);
            
            CreateTable(
                "dbo.DischargeCertificateMasters",
                c => new
                    {
                        DischargeId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        DischareDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.DischargeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DischargeCertificateDetails", "DischargeId", "dbo.DischargeCertificateMasters");
            DropIndex("dbo.DischargeCertificateDetails", new[] { "DischargeId" });
            DropTable("dbo.DischargeCertificateMasters");
            DropTable("dbo.DischargeCertificateDetails");
        }
    }
}
