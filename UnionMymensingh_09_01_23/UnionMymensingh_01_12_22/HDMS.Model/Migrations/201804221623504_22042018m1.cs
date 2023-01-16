namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22042018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "DiscountInPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "DiscountInPercent");
        }
    }
}
