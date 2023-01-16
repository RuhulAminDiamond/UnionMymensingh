namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestGroup_Model_Modified_Dec26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestGroups", "DiscountPlanGroup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestGroups", "DiscountPlanGroup");
        }
    }
}
