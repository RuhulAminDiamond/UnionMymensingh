namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19052018m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Module", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Module", "DisplayOrder");
        }
    }
}
