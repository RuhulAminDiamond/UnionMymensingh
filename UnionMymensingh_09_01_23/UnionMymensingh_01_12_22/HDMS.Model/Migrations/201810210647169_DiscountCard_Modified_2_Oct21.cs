namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCard_Modified_2_Oct21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscountCards", "CardTopLabel", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscountCards", "CardTopLabel");
        }
    }
}
