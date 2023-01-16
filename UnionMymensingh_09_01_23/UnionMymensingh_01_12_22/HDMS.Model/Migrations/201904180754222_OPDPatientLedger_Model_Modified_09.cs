namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPDPatientLedger_Model_Modified_09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDPatientLedgers", "OPDBillId", c => c.Long(nullable: false));
            CreateIndex("dbo.OPDPatientLedgers", "OPDBillId");
           // AddForeignKey("dbo.OPDPatientLedgers", "OPDBillId", "dbo.HpOPDBills", "OPDBillId", cascadeDelete: true);
            DropColumn("dbo.OPDPatientLedgers", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDPatientLedgers", "PatientId", c => c.Long(nullable: false));
            //DropForeignKey("dbo.OPDPatientLedgers", "OPDBillId", "dbo.HpOPDBills");
            DropIndex("dbo.OPDPatientLedgers", new[] { "OPDBillId" });
            DropColumn("dbo.OPDPatientLedgers", "OPDBillId");
        }
    }
}
