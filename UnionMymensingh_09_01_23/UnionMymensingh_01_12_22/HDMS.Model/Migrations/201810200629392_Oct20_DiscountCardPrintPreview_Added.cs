namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oct20_DiscountCardPrintPreview_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountCardPrintViews",
                c => new
                    {
                        SrlNo = c.Long(nullable: false, identity: true),
                        CardType = c.String(),
                        Consultant = c.String(),
                        CardNo1 = c.String(),
                        CardNo2 = c.String(),
                        CardNo3 = c.String(),
                        CardNo4 = c.String(),
                        CardNo5 = c.String(),
                    })
                .PrimaryKey(t => t.SrlNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiscountCardPrintViews");
        }
    }
}
