namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcosost_modified_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestsCost", "SampleReceivedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestsCost", "SampleReceivedDate", c => c.DateTime(nullable: false));
        }
    }
}
