namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22052018m5 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.ReportConsultants");
            CreateTable(
                "dbo.ReportConsultantWorkLists",
                c => new
                    {
                        RCWId = c.Int(nullable: false, identity: true),
                        RCId = c.Int(nullable: false),
                        TestGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RCWId);
            
            AddColumn("dbo.ReportConsultants", "RCId", c => c.Int(nullable: false, identity: true));
           // AddPrimaryKey("dbo.ReportConsultants", "RCId");
            DropColumn("dbo.ReportConsultants", "Id");
            DropColumn("dbo.ReportConsultants", "ConsultantGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportConsultants", "ConsultantGroup", c => c.String());
            AddColumn("dbo.ReportConsultants", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReportConsultants");
            DropColumn("dbo.ReportConsultants", "RCId");
            DropTable("dbo.ReportConsultantWorkLists");
           // AddPrimaryKey("dbo.ReportConsultants", "Id");
        }
    }
}
