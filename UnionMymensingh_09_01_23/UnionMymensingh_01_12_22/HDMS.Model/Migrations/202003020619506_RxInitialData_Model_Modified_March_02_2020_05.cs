namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_March_02_2020_05 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RxInitialDatas", "CreatedUserId");
            CreateIndex("dbo.RxInitialDatas", "ModifiedUserId");
            AddForeignKey("dbo.RxInitialDatas", "CreatedUserId", "dbo.User", "UserId", cascadeDelete: true);
           // AddForeignKey("dbo.RxInitialDatas", "ModifiedUserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxInitialDatas", "ModifiedUserId", "dbo.User");
            DropForeignKey("dbo.RxInitialDatas", "CreatedUserId", "dbo.User");
            DropIndex("dbo.RxInitialDatas", new[] { "ModifiedUserId" });
            DropIndex("dbo.RxInitialDatas", new[] { "CreatedUserId" });
        }
    }
}
