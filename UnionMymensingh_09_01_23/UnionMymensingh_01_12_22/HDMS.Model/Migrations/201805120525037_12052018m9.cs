namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12052018m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestItems", "TestCode", c => c.Int(nullable: false));
            AddColumn("dbo.TestSubItems", "TestCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestSubItems", "TestCode");
            DropColumn("dbo.TestItems", "TestCode");
        }
    }
}
