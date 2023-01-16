namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcost_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "SampleReceivedBy", c => c.String());
            AddColumn("dbo.TestsCost", "SampleReceivedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TestsCost", "SampleReceivedTime", c => c.String());
            DropColumn("dbo.TestsCost", "IsSampleCollected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestsCost", "IsSampleCollected", c => c.Boolean(nullable: false));
            DropColumn("dbo.TestsCost", "SampleReceivedTime");
            DropColumn("dbo.TestsCost", "SampleReceivedDate");
            DropColumn("dbo.TestsCost", "SampleReceivedBy");
        }
    }
}
