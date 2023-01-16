namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Member_Employee_Ledger_Fixing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeLedgers", "TranDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeLedgers", "TransactionType", c => c.String());
            AddColumn("dbo.EmployeeLedgers", "OperateBy", c => c.String());
            AddColumn("dbo.MemberLedgers", "TranDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MemberLedgers", "TransactionType", c => c.String());
            AddColumn("dbo.MemberLedgers", "OperateBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberLedgers", "OperateBy");
            DropColumn("dbo.MemberLedgers", "TransactionType");
            DropColumn("dbo.MemberLedgers", "TranDate");
            DropColumn("dbo.EmployeeLedgers", "OperateBy");
            DropColumn("dbo.EmployeeLedgers", "TransactionType");
            DropColumn("dbo.EmployeeLedgers", "TranDate");
        }
    }
}
