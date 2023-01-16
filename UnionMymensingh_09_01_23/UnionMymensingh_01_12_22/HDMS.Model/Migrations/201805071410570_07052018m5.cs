namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07052018m5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DiscountGivenByRequestInPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DiscountGivenByRequestInPercent", c => c.Int(nullable: false));
        }
    }
}
