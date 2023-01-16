namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16032018m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "RoleId");
        }
    }
}
