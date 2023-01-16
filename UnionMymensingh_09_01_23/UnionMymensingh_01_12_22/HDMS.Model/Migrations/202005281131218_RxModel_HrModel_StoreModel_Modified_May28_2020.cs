namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_HrModel_StoreModel_Modified_May28_2020 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReagentWithTestMappings", newName: "ReagentWithTests");
            CreateTable(
                "dbo.EmpAttendanceRecords",
                c => new
                    {
                        AttRId = c.Long(nullable: false, identity: true),
                        WDId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        AttendaceStatus = c.String(),
                    })
                .PrimaryKey(t => t.AttRId)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.HrWokingDays", t => t.WDId, cascadeDelete: true)
                .Index(t => t.WDId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeLeaveRecords",
                c => new
                    {
                        LRId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        Leavefrom = c.DateTime(nullable: false),
                        Leaveto = c.DateTime(nullable: false),
                        TotalDays = c.Int(nullable: false),
                        LeaveType = c.String(),
                    })
                .PrimaryKey(t => t.LRId);
            
            CreateTable(
                "dbo.HRPolicies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CL = c.Int(nullable: false),
                        ML = c.Int(nullable: false),
                        MedicalLeave = c.Int(nullable: false),
                        AbsentDeduction = c.Boolean(nullable: false),
                        lateConsiderAfterMins = c.Int(nullable: false),
                        OnedaySalaryDeductionForLateInDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveApprovalSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovalLevel_1 = c.String(),
                        ApprovalLevel_2 = c.String(),
                        ApprovalLevel_3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanInstallmentCollections",
                c => new
                    {
                        LCId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        LoanId = c.Long(nullable: false),
                        InstallmentNo = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false),
                        CAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LCId);
            
            CreateTable(
                "dbo.StoreDeptUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreDepts", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DeptId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TempGAttendanceLogDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MachineNumber = c.Int(nullable: false),
                        IndRegID = c.Int(nullable: false),
                        DateTimeRecord = c.String(),
                        DateOnlyRecord = c.DateTime(nullable: false),
                        TimeOnlyRecord = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StoreRequisitions", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.StoreDepts", "IndentUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreDepts", "IndentUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StoreDeptUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.StoreDeptUsers", "DeptId", "dbo.StoreDepts");
            DropForeignKey("dbo.EmpAttendanceRecords", "WDId", "dbo.HrWokingDays");
            DropForeignKey("dbo.EmpAttendanceRecords", "EmployeeId", "dbo.EmployeeInfoes");
            DropIndex("dbo.StoreDeptUsers", new[] { "UserId" });
            DropIndex("dbo.StoreDeptUsers", new[] { "DeptId" });
            DropIndex("dbo.EmpAttendanceRecords", new[] { "EmployeeId" });
            DropIndex("dbo.EmpAttendanceRecords", new[] { "WDId" });
            DropColumn("dbo.StoreRequisitions", "UserId");
            DropTable("dbo.TempGAttendanceLogDatas");
            DropTable("dbo.StoreDeptUsers");
            DropTable("dbo.LoanInstallmentCollections");
            DropTable("dbo.LeaveApprovalSettings");
            DropTable("dbo.HRPolicies");
            DropTable("dbo.EmployeeLeaveRecords");
            DropTable("dbo.EmpAttendanceRecords");
            RenameTable(name: "dbo.ReagentWithTests", newName: "ReagentWithTestMappings");
        }
    }
}
