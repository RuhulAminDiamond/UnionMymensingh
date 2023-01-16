namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_Module_Added_And_Modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BGType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpDivisions",
                c => new
                    {
                        DivId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DivId);
            
            CreateTable(
                "dbo.EmployeeRosterMasterInfoes",
                c => new
                    {
                        RosterMasterId = c.Long(nullable: false, identity: true),
                        RosterStartDate = c.DateTime(nullable: false),
                        RosterEndDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        DeptId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RosterMasterId);
            
            CreateTable(
                "dbo.EmployeeRosters",
                c => new
                    {
                        RosterId = c.Long(nullable: false, identity: true),
                        RosterDate = c.DateTime(nullable: false),
                        RosterDay = c.String(),
                        RosterOrder = c.Int(nullable: false),
                        MorningEmpid = c.String(),
                        MorningEmpName = c.String(),
                        EveningEmpid = c.String(),
                        EveningEmpName = c.String(),
                        NightEmpid = c.String(),
                        NightEmpName = c.String(),
                        OverTimeEmpid = c.String(),
                        OverTimeEmpName = c.String(),
                        DayOffEmpid = c.String(),
                        DayOffEmpName = c.String(),
                        DeptId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        MasterRosterID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RosterId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HRSalaryPolicy",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        HouseRentInPercentOfBasic = c.Double(nullable: false),
                        MedicalAllownceInPercentOfBasic = c.Double(nullable: false),
                        MobileAllownceTk = c.Double(nullable: false),
                        TransportAllownceTk = c.Double(nullable: false),
                        FestivalBonusInPercentOfBasic = c.Double(nullable: false),
                        OvertimePerHour = c.Double(nullable: false),
                        LateDeductionPerHour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyId);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EmployeeInfoes", "EmployeeNo", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "FirstName", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "MiddleName", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "LastName", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "FatherName", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "MotherName", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "PermanentAddress", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "PresentAddress", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "MobileNo", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "EmailId", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "BloodGroup", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "Religion", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "DateofBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "Sex", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "MaritalStatus", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "Nationality", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "NationIDorPPNo", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "EmpDivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "Confirmationdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "BasicSalary", c => c.Double(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "OtherBenifits", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "EmployeeCategory", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "EmployeeJobLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeInfoes", "EmployeeJobLocation");
            DropColumn("dbo.EmployeeInfoes", "EmployeeCategory");
            DropColumn("dbo.EmployeeInfoes", "OtherBenifits");
            DropColumn("dbo.EmployeeInfoes", "BasicSalary");
            DropColumn("dbo.EmployeeInfoes", "Confirmationdate");
            DropColumn("dbo.EmployeeInfoes", "EmpDivisionId");
            DropColumn("dbo.EmployeeInfoes", "NationIDorPPNo");
            DropColumn("dbo.EmployeeInfoes", "Nationality");
            DropColumn("dbo.EmployeeInfoes", "MaritalStatus");
            DropColumn("dbo.EmployeeInfoes", "Sex");
            DropColumn("dbo.EmployeeInfoes", "DateofBirth");
            DropColumn("dbo.EmployeeInfoes", "Religion");
            DropColumn("dbo.EmployeeInfoes", "BloodGroup");
            DropColumn("dbo.EmployeeInfoes", "EmailId");
            DropColumn("dbo.EmployeeInfoes", "MobileNo");
            DropColumn("dbo.EmployeeInfoes", "PresentAddress");
            DropColumn("dbo.EmployeeInfoes", "PermanentAddress");
            DropColumn("dbo.EmployeeInfoes", "MotherName");
            DropColumn("dbo.EmployeeInfoes", "FatherName");
            DropColumn("dbo.EmployeeInfoes", "LastName");
            DropColumn("dbo.EmployeeInfoes", "MiddleName");
            DropColumn("dbo.EmployeeInfoes", "FirstName");
            DropColumn("dbo.EmployeeInfoes", "EmployeeNo");
            DropTable("dbo.Religions");
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.HRSalaryPolicy");
            DropTable("dbo.Genders");
            DropTable("dbo.EmployeeRosters");
            DropTable("dbo.EmployeeRosterMasterInfoes");
            DropTable("dbo.EmpDivisions");
            DropTable("dbo.BloodGroups");
        }
    }
}
