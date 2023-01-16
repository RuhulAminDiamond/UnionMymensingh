namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "ROL", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "ROL");
        }
    }
}
