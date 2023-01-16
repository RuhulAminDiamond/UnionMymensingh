namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17032018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "IsSampleCollected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "IsSampleCollected");
        }
    }
}
