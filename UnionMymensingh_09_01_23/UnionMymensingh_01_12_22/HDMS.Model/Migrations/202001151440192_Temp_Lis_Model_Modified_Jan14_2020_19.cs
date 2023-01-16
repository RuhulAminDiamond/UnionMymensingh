namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_Lis_Model_Modified_Jan14_2020_19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TEMPLISPatientRecords",
                c => new
                    {
                        PatientRecordId = c.Long(nullable: false, identity: true),
                        InterfacingDbPatientRecordId = c.Long(nullable: false),
                        PatientId = c.Long(nullable: false),
                        ReportId = c.String(),
                        SequenceId_02 = c.Int(),
                        InstrumentName = c.String(),
                        ReportDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientRecordId);
            
            CreateTable(
                "dbo.TEMPLISResultRecords",
                c => new
                    {
                        ResultRecordId = c.Long(nullable: false, identity: true),
                        PatientRecordId = c.Long(nullable: false),
                        ReportDefId = c.Int(nullable: false),
                        Category = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                        LongName = c.String(),
                        Value = c.String(),
                        Unit = c.String(),
                        Range = c.String(),
                        ReportDate = c.DateTime(),
                        ResultProducedBy_02 = c.String(),
                    })
                .PrimaryKey(t => t.ResultRecordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TEMPLISResultRecords");
            DropTable("dbo.TEMPLISPatientRecords");
        }
    }
}
