namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20032018m1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestSubItems", "Rate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestSubItems", "Rate", c => c.Single(nullable: false));
        }
    }
}
