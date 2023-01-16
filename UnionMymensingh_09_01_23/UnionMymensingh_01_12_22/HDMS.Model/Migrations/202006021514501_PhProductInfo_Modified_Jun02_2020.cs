namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhProductInfo_Modified_Jun02_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhProductInfoes", "DoseShortEn", c => c.String());
            AddColumn("dbo.PhProductInfoes", "DoseShortBn", c => c.String());
            AddColumn("dbo.PhProductInfoes", "DoseLongEn", c => c.String());
            AddColumn("dbo.PhProductInfoes", "DoseLongBn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhProductInfoes", "DoseLongBn");
            DropColumn("dbo.PhProductInfoes", "DoseLongEn");
            DropColumn("dbo.PhProductInfoes", "DoseShortBn");
            DropColumn("dbo.PhProductInfoes", "DoseShortEn");
        }
    }
}
