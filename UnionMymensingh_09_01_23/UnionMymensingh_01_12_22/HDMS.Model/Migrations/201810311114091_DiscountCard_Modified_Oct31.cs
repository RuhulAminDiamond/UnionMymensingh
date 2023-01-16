namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCard_Modified_Oct31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscountCards", "CardNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscountCards", "CardNo", c => c.Long(nullable: false));
        }
    }
}
