namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPrintPreference_Model_Modified_Apr09_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPrintPreferences", "DoseEnLanguage", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxPrintPreferences", "DoseShortEnLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPrintPreferences", "DoseShortEnLanguage", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxPrintPreferences", "DoseEnLanguage");
        }
    }
}
