namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6012018m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "AssignedOutLet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "AssignedOutLet");
        }
    }
}
