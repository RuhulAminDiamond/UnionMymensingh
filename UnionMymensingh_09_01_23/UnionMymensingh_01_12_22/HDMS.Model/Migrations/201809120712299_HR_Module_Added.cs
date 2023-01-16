namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR_Module_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpDepartments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.EmpDesignations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        DeptId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            AddColumn("dbo.HospitalPatientInfoes", "BillPrintState", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "BillPrintState");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.EmpDesignations");
            DropTable("dbo.EmpDepartments");
        }
    }
}
