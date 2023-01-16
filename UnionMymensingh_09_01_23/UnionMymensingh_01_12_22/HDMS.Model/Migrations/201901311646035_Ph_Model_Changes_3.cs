namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ph_Model_Changes_3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PhLotInfoes", "UserId");
            AddForeignKey("dbo.PhLotInfoes", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhLotInfoes", "UserId", "dbo.User");
            DropIndex("dbo.PhLotInfoes", new[] { "UserId" });
        }
    }
}
