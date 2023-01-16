namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Patient_Record_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDPatientRecords", "ServiceGroupId", c => c.Int(nullable: false));
            DropColumn("dbo.OPDPatientRecords", "ReportIdPrefix");
            DropColumn("dbo.OPDPatientRecords", "ReportId");
            DropColumn("dbo.OPDPatientRecords", "RxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDPatientRecords", "RxId", c => c.Long(nullable: false));
            AddColumn("dbo.OPDPatientRecords", "ReportId", c => c.Long(nullable: false));
            AddColumn("dbo.OPDPatientRecords", "ReportIdPrefix", c => c.String());
            DropColumn("dbo.OPDPatientRecords", "ServiceGroupId");
        }
    }
}
