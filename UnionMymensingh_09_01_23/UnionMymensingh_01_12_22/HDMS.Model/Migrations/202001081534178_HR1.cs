namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobCirculations",
                c => new
                    {
                        JCId = c.Int(nullable: false, identity: true),
                        CirculationNo = c.String(),
                        CirculationTitle = c.String(),
                    })
                .PrimaryKey(t => t.JCId);
            
            CreateTable(
                "dbo.JobCVs",
                c => new
                    {
                        JCVId = c.Int(nullable: false, identity: true),
                        JCId = c.Int(nullable: false),
                        Applyfor = c.String(),
                        ApplicatName = c.String(),
                        ApplicatMobileNo = c.String(),
                        FileName = c.String(),
                        CVInPdf = c.Binary(),
                        CVInWord = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.JCVId)
                .ForeignKey("dbo.JobCirculations", t => t.JCId, cascadeDelete: true)
                .Index(t => t.JCId);
            
            AddColumn("dbo.EmpDepartments", "DivId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "JCId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "JCVId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "BiometricEnrollmentNo", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "IsHoD", c => c.Boolean(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "EmployeeId", c => c.Long(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "BasicAmount", c => c.Double(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "TaxDeduction", c => c.Double(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "PfDeduction", c => c.Double(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "InsuranceDeduction", c => c.Double(nullable: false));
            DropColumn("dbo.EmployeeInfoes", "BasicSalary");
            DropColumn("dbo.EmployeeInfoes", "OtherBenifits");
            DropColumn("dbo.HRSalaryPolicy", "DeptId");
            DropColumn("dbo.HRSalaryPolicy", "DesignationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HRSalaryPolicy", "DesignationId", c => c.Int(nullable: false));
            AddColumn("dbo.HRSalaryPolicy", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "OtherBenifits", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "BasicSalary", c => c.Double(nullable: false));
            DropForeignKey("dbo.JobCVs", "JCId", "dbo.JobCirculations");
            DropIndex("dbo.JobCVs", new[] { "JCId" });
            DropColumn("dbo.HRSalaryPolicy", "InsuranceDeduction");
            DropColumn("dbo.HRSalaryPolicy", "PfDeduction");
            DropColumn("dbo.HRSalaryPolicy", "TaxDeduction");
            DropColumn("dbo.HRSalaryPolicy", "BasicAmount");
            DropColumn("dbo.HRSalaryPolicy", "EmployeeId");
            DropColumn("dbo.EmployeeInfoes", "IsHoD");
            DropColumn("dbo.EmployeeInfoes", "BiometricEnrollmentNo");
            DropColumn("dbo.EmployeeInfoes", "JCVId");
            DropColumn("dbo.EmployeeInfoes", "JCId");
            DropColumn("dbo.EmpDepartments", "DivId");
            DropTable("dbo.JobCVs");
            DropTable("dbo.JobCirculations");
        }
    }
}
