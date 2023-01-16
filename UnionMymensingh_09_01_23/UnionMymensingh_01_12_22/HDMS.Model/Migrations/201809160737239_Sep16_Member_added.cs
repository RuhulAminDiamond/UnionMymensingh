namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep16_Member_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberInfoes",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberInfoes");
        }
    }
}
