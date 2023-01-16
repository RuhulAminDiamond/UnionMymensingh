namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612018m11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceives", "OutLetId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhReceives", "OutLetId");
        }
    }
}
