namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24062018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegUniqueKeyTrackers", "RegYear", c => c.Int(nullable: false));
            AddColumn("dbo.RegUniqueKeyTrackers", "RegMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegUniqueKeyTrackers", "RegMonth");
            DropColumn("dbo.RegUniqueKeyTrackers", "RegYear");
        }
    }
}
