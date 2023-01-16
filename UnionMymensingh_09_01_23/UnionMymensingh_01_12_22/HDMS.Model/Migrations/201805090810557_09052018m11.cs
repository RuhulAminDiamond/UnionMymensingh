namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09052018m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestGroups", "MasterTestGroupId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestGroups", "MasterTestGroupId");
        }
    }
}
