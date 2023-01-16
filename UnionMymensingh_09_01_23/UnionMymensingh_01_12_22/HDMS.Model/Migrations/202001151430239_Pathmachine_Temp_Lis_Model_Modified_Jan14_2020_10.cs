namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pathmachine_Temp_Lis_Model_Modified_Jan14_2020_10 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TEMP_LIS_PatientRecord");
            DropTable("dbo.TEMP_LIS_ResultRecord");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TEMP_LIS_ResultRecord",
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
                        ResultProducedBy = c.String(),
                    })
                .PrimaryKey(t => t.ResultRecordId);
            
            CreateTable(
                "dbo.TEMP_LIS_PatientRecord",
                c => new
                    {
                        PatientRecordId = c.Long(nullable: false, identity: true),
                        InterfacingDbPatientRecordId = c.Long(nullable: false),
                        PatientId = c.Long(nullable: false),
                        ReportId = c.String(),
                        SequenceId = c.Int(),
                        InstrumentName = c.String(),
                        ReportDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientRecordId);
            
        }
    }
}
