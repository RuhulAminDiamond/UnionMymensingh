namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oct20_DiscountCard_Modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscountCards", "UsedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscountCards", "UsedDate", c => c.DateTime(nullable: false));
        }
    }
}
