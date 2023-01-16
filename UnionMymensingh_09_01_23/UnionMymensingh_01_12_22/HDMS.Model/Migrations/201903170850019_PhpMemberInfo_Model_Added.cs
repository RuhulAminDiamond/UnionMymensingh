namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhpMemberInfo_Model_Added : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeLedgers", newName: "PhMemberLedgers");
            AddColumn("dbo.PhMemberLedgers", "TransactionTime", c => c.String());
            AddColumn("dbo.PhMemberLedgers", "MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.PhMemberLedgers", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhMemberLedgers", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.PhMemberLedgers", "MemberId");
            DropColumn("dbo.PhMemberLedgers", "TransactionTime");
            RenameTable(name: "dbo.PhMemberLedgers", newName: "EmployeeLedgers");
        }
    }
}
