namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabinInfoes", "IsBooked", c => c.Boolean(nullable: false));
            AddColumn("dbo.WardBedInfoes", "IsBooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WardBedInfoes", "IsBooked");
            DropColumn("dbo.CabinInfoes", "IsBooked");
        }
    }
}
