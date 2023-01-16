namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Changes_March_15_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarketingAgents",
                c => new
                    {
                        MAId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MAId);
            
            AddColumn("dbo.PractitionerWisePatientSerials", "VisitTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.PractitionerWisePatientSerials", "MAId", c => c.Int(nullable: false));
            AddColumn("dbo.PractitionerWisePatientSerials", "Remarks", c => c.String());
            AddColumn("dbo.PractitionerWisePatientSerials", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PractitionerWisePatientSerials", "Status");
            DropColumn("dbo.PractitionerWisePatientSerials", "Remarks");
            DropColumn("dbo.PractitionerWisePatientSerials", "MAId");
            DropColumn("dbo.PractitionerWisePatientSerials", "VisitTypeId");
            DropTable("dbo.MarketingAgents");
        }
    }
}
