namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oct20_DiscountCard_Type_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountCards",
                c => new
                    {
                        CardId = c.Long(nullable: false, identity: true),
                        CardTypeId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        CardNo = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        status = c.String(),
                        UsedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.DiscountCardTypes", t => t.CardTypeId, cascadeDelete: true)
                .Index(t => t.CardTypeId);
            
            CreateTable(
                "dbo.DiscountCardTypes",
                c => new
                    {
                        CardTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DiscountInPercent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CardTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscountCards", "CardTypeId", "dbo.DiscountCardTypes");
            DropIndex("dbo.DiscountCards", new[] { "CardTypeId" });
            DropTable("dbo.DiscountCardTypes");
            DropTable("dbo.DiscountCards");
        }
    }
}
