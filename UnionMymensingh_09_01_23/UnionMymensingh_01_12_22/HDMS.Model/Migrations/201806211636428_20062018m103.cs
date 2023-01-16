namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m103 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.RegUniqueKeyTrackers");
            AlterColumn("dbo.RegUniqueKeyTrackers", "RegNo", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.RegUniqueKeyTrackers", "RegNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RegUniqueKeyTrackers");
            AlterColumn("dbo.RegUniqueKeyTrackers", "RegNo", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.RegUniqueKeyTrackers", "RegNo");
        }
    }
}
