namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LIS_Module_Remove : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PatientRecords");
            DropTable("dbo.ResultRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResultRecords",
                c => new
                    {
                        ResultRecordId = c.Long(nullable: false, identity: true),
                        PatientRecordId = c.Long(nullable: false),
                        Category = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                        LongName = c.String(),
                        Value = c.String(),
                        Unit = c.String(),
                        Range = c.String(),
                        ReportDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ResultRecordId);
            
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        PatientRecordId = c.Long(nullable: false, identity: true),
                        PatientId = c.String(),
                        SequenceId = c.Int(),
                        InstrumentName = c.String(),
                        ReportDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientRecordId);
            
        }
    }
}
