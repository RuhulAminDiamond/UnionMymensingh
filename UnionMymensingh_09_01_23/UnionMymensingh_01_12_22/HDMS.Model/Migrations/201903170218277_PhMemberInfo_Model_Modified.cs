namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhMemberInfo_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhMemberInfoes", "EmployeeId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhMemberInfoes", "EmployeeId", c => c.Int(nullable: false));
        }
    }
}
