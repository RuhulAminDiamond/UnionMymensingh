namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Model_Modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDPatientLedgerRoughs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OPDPatientRecords", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.OPDPatientVisitTypes",
                c => new
                    {
                        VisitTypeId = c.Int(nullable: false, identity: true),
                        VisitType = c.String(),
                        VisitTypeCode = c.String(),
                    })
                .PrimaryKey(t => t.VisitTypeId);
            
            AddColumn("dbo.Doctor", "ConsultancyFeeOld", c => c.Double(nullable: false));
            AddColumn("dbo.Doctor", "ConsultancyFeeReportOpinion", c => c.Double(nullable: false));
            AddColumn("dbo.OPDPatientRecords", "VisitTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDPatientLedgerRoughs", "PatientId", "dbo.OPDPatientRecords");
            DropIndex("dbo.OPDPatientLedgerRoughs", new[] { "PatientId" });
            DropColumn("dbo.OPDPatientRecords", "VisitTypeId");
            DropColumn("dbo.Doctor", "ConsultancyFeeReportOpinion");
            DropColumn("dbo.Doctor", "ConsultancyFeeOld");
            DropTable("dbo.OPDPatientVisitTypes");
            DropTable("dbo.OPDPatientLedgerRoughs");
        }
    }
}
