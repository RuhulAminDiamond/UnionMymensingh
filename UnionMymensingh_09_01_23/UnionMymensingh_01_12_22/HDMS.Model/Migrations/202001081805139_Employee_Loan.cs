namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_Loan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpLoanInfoes",
                c => new
                    {
                        LoanId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        IssueAmount = c.Double(nullable: false),
                        NoOfInstallment = c.Int(nullable: false),
                        AmountPerInstallment = c.Double(nullable: false),
                        InstallmentStartMonth = c.String(),
                        InstallmentStartYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmpLoanInfoes");
        }
    }
}
