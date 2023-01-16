namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR_Model_Added_Jan11_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimedAttendanceLogPullHistories",
                c => new
                    {
                        PullId = c.Long(nullable: false, identity: true),
                        PullFromDate = c.DateTime(nullable: false),
                        PullFromTime = c.String(),
                        PullToDate = c.DateTime(nullable: false),
                        PullToTime = c.String(),
                        PullFromSortableDateTime = c.String(),
                        PullToSortableDateTime = c.String(),
                    })
                .PrimaryKey(t => t.PullId);
            
            CreateTable(
                "dbo.TimedAttendanceLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PullId = c.Long(nullable: false),
                        MachineNumber = c.Int(nullable: false),
                        IndRegID = c.Int(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        BDate = c.DateTime(nullable: false),
                        InTime = c.String(),
                        OutTime = c.String(),
                        Remarks = c.String(),
                        InSortableDateTime = c.DateTime(nullable: false),
                        OutSortableDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimedAttendanceLogPullHistories", t => t.PullId, cascadeDelete: true)
                .Index(t => t.PullId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimedAttendanceLogs", "PullId", "dbo.TimedAttendanceLogPullHistories");
            DropIndex("dbo.TimedAttendanceLogs", new[] { "PullId" });
            DropTable("dbo.TimedAttendanceLogs");
            DropTable("dbo.TimedAttendanceLogPullHistories");
        }
    }
}
