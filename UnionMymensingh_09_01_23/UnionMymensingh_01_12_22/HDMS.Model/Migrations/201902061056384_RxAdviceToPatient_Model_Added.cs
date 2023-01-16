namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxAdviceToPatient_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxAdviceToPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdviceId = c.Int(nullable: false),
                        RxId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RxPatientInfoes", "PastHistory", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "Advices");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "Advices", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "PastHistory");
            DropTable("dbo.RxAdviceToPatients");
        }
    }
}
