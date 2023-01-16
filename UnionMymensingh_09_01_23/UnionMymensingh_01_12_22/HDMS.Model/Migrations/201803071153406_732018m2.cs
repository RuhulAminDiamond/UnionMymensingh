namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _732018m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "User_UserId", c => c.Int());
            CreateIndex("dbo.Role", "User_UserId");
            AddForeignKey("dbo.Role", "User_UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "User_UserId", "dbo.User");
            DropIndex("dbo.Role", new[] { "User_UserId" });
            DropColumn("dbo.Role", "User_UserId");
        }
    }
}
