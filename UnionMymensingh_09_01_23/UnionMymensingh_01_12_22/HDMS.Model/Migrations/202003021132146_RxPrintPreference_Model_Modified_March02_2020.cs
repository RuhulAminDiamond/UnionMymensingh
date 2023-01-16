namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPrintPreference_Model_Modified_March02_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPrintPreferences", "AdvicesEnLanguage", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "DoseShortDescription", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "DoseShortEnLanguage", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxPrintPreferences", "Advices");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPrintPreferences", "Advices", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxPrintPreferences", "DoseShortEnLanguage");
            DropColumn("dbo.RxPrintPreferences", "DoseShortDescription");
            DropColumn("dbo.RxPrintPreferences", "AdvicesEnLanguage");
        }
    }
}
