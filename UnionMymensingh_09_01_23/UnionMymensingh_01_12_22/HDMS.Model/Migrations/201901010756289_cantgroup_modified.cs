namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cantgroup_modified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CantGroups", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CantGroups", "ParentId", c => c.Int(nullable: false));
        }
    }
}
