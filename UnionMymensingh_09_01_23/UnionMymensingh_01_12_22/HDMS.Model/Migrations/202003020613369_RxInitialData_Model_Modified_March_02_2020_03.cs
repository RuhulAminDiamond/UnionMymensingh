namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Modified_March_02_2020_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxInitialDatas", "CreatedUserId", c => c.Int(nullable: false));
            AddColumn("dbo.RxInitialDatas", "ModifiedUserId", c => c.Int(nullable: false));
            DropColumn("dbo.RxInitialDatas", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxInitialDatas", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.RxInitialDatas", "ModifiedUserId");
            DropColumn("dbo.RxInitialDatas", "CreatedUserId");
        }
    }
}
