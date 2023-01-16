namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07052018m3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Doctor", "UserId");
            AddForeignKey("dbo.Doctor", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctor", "UserId", "dbo.User");
            DropIndex("dbo.Doctor", new[] { "UserId" });
        }
    }
}
