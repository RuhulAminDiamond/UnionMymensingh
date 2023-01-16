namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28042018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "Discount", c => c.String());
            AlterColumn("dbo.TestsCost", "DiscountInPercent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestsCost", "DiscountInPercent", c => c.Double(nullable: false));
            DropColumn("dbo.TestsCost", "Discount");
        }
    }
}
