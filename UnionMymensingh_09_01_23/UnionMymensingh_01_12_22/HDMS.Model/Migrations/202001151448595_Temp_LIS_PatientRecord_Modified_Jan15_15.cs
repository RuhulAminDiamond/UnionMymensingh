namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_LIS_PatientRecord_Modified_Jan15_15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TEMPLISPatientRecords", "SequenceId", c => c.Int());
            AddColumn("dbo.TEMPLISResultRecords", "ResultProducedBy", c => c.String());
            DropColumn("dbo.TEMPLISPatientRecords", "SequenceId_02");
            DropColumn("dbo.TEMPLISResultRecords", "ResultProducedBy_02");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TEMPLISResultRecords", "ResultProducedBy_02", c => c.String());
            AddColumn("dbo.TEMPLISPatientRecords", "SequenceId_02", c => c.Int());
            DropColumn("dbo.TEMPLISResultRecords", "ResultProducedBy");
            DropColumn("dbo.TEMPLISPatientRecords", "SequenceId");
        }
    }
}
