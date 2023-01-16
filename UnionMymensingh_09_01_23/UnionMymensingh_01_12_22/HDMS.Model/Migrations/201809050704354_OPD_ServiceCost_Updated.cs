namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_ServiceCost_Updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDServiceCosts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        ServiceOrConsultantId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OPDPatientRecords", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.OPDServiceGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.GroupId);
            
            DropColumn("dbo.OPDPatientRecords", "ServiceGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDPatientRecords", "ServiceGroupId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OPDServiceCosts", "GroupId", "dbo.OPDServiceGroups");
            DropForeignKey("dbo.OPDServiceCosts", "PatientId", "dbo.OPDPatientRecords");
            DropIndex("dbo.OPDServiceCosts", new[] { "GroupId" });
            DropIndex("dbo.OPDServiceCosts", new[] { "PatientId" });
            DropTable("dbo.OPDServiceCosts");
        }
    }
}
