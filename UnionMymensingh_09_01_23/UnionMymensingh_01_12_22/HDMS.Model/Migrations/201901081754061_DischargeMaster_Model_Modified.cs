namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DischargeMaster_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargeCertificateMasters", "RCId", c => c.Int(nullable: false));
            CreateIndex("dbo.DischargeCertificateMasters", "RCId");
            AddForeignKey("dbo.DischargeCertificateMasters", "RCId", "dbo.ReportConsultants", "RCId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DischargeCertificateMasters", "RCId", "dbo.ReportConsultants");
            DropIndex("dbo.DischargeCertificateMasters", new[] { "RCId" });
            DropColumn("dbo.DischargeCertificateMasters", "RCId");
        }
    }
}
