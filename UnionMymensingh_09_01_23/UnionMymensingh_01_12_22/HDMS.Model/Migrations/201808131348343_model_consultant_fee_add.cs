namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_consultant_fee_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsultantFees",
                c => new
                    {
                        CFId = c.Int(nullable: false, identity: true),
                        RCId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        FeeInPercent = c.Int(nullable: false),
                        FeeInGross = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CFId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConsultantFees");
        }
    }
}
