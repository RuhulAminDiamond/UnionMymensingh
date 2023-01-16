namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCardMaster_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscountCards", "CardTypeId", "dbo.DiscountCardTypes");
            DropIndex("dbo.DiscountCards", new[] { "CardTypeId" });
            CreateTable(
                "dbo.DiscountCardMasters",
                c => new
                    {
                        DCMId = c.Long(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        CardTopLabel = c.String(),
                        CardTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.DCMId)
                .ForeignKey("dbo.DiscountCardTypes", t => t.CardTypeId, cascadeDelete: true)
                .Index(t => t.CardTypeId);
            
            AddColumn("dbo.DiscountCards", "DCMId", c => c.Long(nullable: false));
            CreateIndex("dbo.DiscountCards", "DCMId");
            AddForeignKey("dbo.DiscountCards", "DCMId", "dbo.DiscountCardMasters", "DCMId", cascadeDelete: true);
            DropColumn("dbo.DiscountCards", "CardTypeId");
            DropColumn("dbo.DiscountCards", "DoctorId");
            DropColumn("dbo.DiscountCards", "CardTopLabel");
            DropColumn("dbo.DiscountCards", "CreateDate");
            DropColumn("dbo.DiscountCards", "ExpireDate");
            DropColumn("dbo.DiscountCards", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiscountCards", "CreatedBy", c => c.String());
            AddColumn("dbo.DiscountCards", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DiscountCards", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DiscountCards", "CardTopLabel", c => c.String());
            AddColumn("dbo.DiscountCards", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.DiscountCards", "CardTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DiscountCards", "DCMId", "dbo.DiscountCardMasters");
            DropForeignKey("dbo.DiscountCardMasters", "CardTypeId", "dbo.DiscountCardTypes");
            DropIndex("dbo.DiscountCards", new[] { "DCMId" });
            DropIndex("dbo.DiscountCardMasters", new[] { "CardTypeId" });
            DropColumn("dbo.DiscountCards", "DCMId");
            DropTable("dbo.DiscountCardMasters");
            CreateIndex("dbo.DiscountCards", "CardTypeId");
            AddForeignKey("dbo.DiscountCards", "CardTypeId", "dbo.DiscountCardTypes", "CardTypeId", cascadeDelete: true);
        }
    }
}
