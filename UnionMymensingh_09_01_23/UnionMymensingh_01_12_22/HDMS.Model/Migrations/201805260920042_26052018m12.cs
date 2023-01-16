namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26052018m12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestGroups", "MovementOrderr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestGroups", "MovementOrderr");
        }
    }
}
