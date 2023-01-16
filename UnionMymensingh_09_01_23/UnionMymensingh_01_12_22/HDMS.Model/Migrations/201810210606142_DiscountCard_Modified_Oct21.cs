namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCard_Modified_Oct21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscountCards", "ExpireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscountCards", "ExpireDate");
        }
    }
}
