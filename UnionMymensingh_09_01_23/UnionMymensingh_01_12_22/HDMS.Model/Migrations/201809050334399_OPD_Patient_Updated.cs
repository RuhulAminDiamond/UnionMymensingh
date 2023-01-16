namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Patient_Updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OPDPatientRecords", "AdmissionNo");
            DropColumn("dbo.OPDPatientRecords", "DeliveryDate");
            DropColumn("dbo.OPDPatientRecords", "DeliveryTime");
            DropColumn("dbo.OPDPatientRecords", "Isfree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPDPatientRecords", "Isfree", c => c.Boolean(nullable: false));
            AddColumn("dbo.OPDPatientRecords", "DeliveryTime", c => c.String());
            AddColumn("dbo.OPDPatientRecords", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OPDPatientRecords", "AdmissionNo", c => c.Long(nullable: false));
        }
    }
}
