namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhMemberInfo_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhMemberInfoes",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MembershipCategory = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhMemberInfoes");
        }
    }
}
