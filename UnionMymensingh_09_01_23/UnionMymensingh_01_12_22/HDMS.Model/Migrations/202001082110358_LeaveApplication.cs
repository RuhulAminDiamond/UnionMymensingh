namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveApplications",
                c => new
                    {
                        ApplicationId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        AppDate = c.DateTime(nullable: false),
                        ApplicationTo = c.String(),
                        ApplicationThrough = c.String(),
                        AppSubject = c.String(),
                        Application = c.String(),
                        ApprovalStatusLevel1 = c.String(),
                        ApprovalStatusLevel2 = c.String(),
                        ApprovalStatusLevel3 = c.String(),
                        Leavefrom = c.DateTime(nullable: false),
                        Leaveto = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            AddColumn("dbo.User", "EmployeeId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "EmployeeId");
            DropTable("dbo.LeaveApplications");
        }
    }
}
