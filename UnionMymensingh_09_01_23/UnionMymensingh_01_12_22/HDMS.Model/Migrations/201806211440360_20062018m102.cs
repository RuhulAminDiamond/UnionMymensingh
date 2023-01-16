namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegUniqueKeyTrackers", "IsUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegUniqueKeyTrackers", "IsUsed");
        }
    }
}
