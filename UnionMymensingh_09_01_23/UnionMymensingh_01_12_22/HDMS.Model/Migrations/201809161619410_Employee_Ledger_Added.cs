namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_Ledger_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TranId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeLedgers");
        }
    }
}
