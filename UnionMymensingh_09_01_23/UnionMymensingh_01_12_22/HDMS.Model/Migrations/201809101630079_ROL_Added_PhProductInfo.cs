namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ROL_Added_PhProductInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "ROLIndoor", c => c.Int(nullable: false));
            AddColumn("dbo.PhProductInfoes", "ROLOutdoor", c => c.Int(nullable: false));
            DropColumn("dbo.PhProductInfoes", "ROL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhProductInfoes", "ROL", c => c.Int(nullable: false));
            DropColumn("dbo.PhProductInfoes", "ROLOutdoor");
            DropColumn("dbo.PhProductInfoes", "ROLIndoor");
        }
    }
}
