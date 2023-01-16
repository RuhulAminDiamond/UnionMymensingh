namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcost_modified_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "SampleCollectedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "SampleCollectedBy");
        }
    }
}
