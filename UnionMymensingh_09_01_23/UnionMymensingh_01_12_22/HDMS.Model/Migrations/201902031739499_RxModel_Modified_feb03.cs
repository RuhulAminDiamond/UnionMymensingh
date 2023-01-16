namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Modified_feb03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxAdvices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Advice = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RxId = c.Long(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RxPatientInfoes", "RxTime", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PatientType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxPatientInfoes", "PatientType");
            DropColumn("dbo.RxPatientInfoes", "RxTime");
            DropTable("dbo.RxTests");
            DropTable("dbo.RxAdvices");
        }
    }
}
