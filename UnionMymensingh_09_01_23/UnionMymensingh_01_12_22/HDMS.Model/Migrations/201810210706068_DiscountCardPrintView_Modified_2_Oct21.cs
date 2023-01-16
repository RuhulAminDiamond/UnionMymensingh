namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCardPrintView_Modified_2_Oct21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscountCardPrintViews", "topLabel", c => c.String());
            AlterColumn("dbo.DiscountCards", "CardTopLabel", c => c.String());
            DropColumn("dbo.DiscountCardPrintViews", "Consultant");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiscountCardPrintViews", "Consultant", c => c.String());
            AlterColumn("dbo.DiscountCards", "CardTopLabel", c => c.Long(nullable: false));
            DropColumn("dbo.DiscountCardPrintViews", "topLabel");
        }
    }
}
