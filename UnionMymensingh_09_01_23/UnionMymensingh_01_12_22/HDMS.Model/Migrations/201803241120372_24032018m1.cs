namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24032018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DiscountInPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DiscountInPercent");
        }
    }
}
