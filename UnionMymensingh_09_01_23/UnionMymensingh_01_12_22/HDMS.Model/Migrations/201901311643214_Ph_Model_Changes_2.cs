namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ph_Model_Changes_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhLotInfoes", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhLotInfoes", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PhLotInfoes", "ModifyBy", c => c.Int(nullable: false));
            AddColumn("dbo.PhLotInfoes", "ModifyDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhLotInfoes", "ModifyDate");
            DropColumn("dbo.PhLotInfoes", "ModifyBy");
            DropColumn("dbo.PhLotInfoes", "UserId");
            DropColumn("dbo.PhLotInfoes", "CreateDate");
        }
    }
}
