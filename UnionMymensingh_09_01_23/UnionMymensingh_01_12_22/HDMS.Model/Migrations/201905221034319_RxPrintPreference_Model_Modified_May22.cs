namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPrintPreference_Model_Modified_May22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPrintPreferences", "ChiefComplains", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "ChiefComplainsWithHistory", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "BP", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Pulse", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Weight", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "PhysicalExam", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Investigations", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Treatment", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Advices", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "Diagnosis", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxPrintPreferences", "PrefName");
            DropColumn("dbo.RxPrintPreferences", "IsPrintable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPrintPreferences", "IsPrintable", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "PrefName", c => c.String());
            DropColumn("dbo.RxPrintPreferences", "Diagnosis");
            DropColumn("dbo.RxPrintPreferences", "Advices");
            DropColumn("dbo.RxPrintPreferences", "Treatment");
            DropColumn("dbo.RxPrintPreferences", "Investigations");
            DropColumn("dbo.RxPrintPreferences", "PhysicalExam");
            DropColumn("dbo.RxPrintPreferences", "Weight");
            DropColumn("dbo.RxPrintPreferences", "Pulse");
            DropColumn("dbo.RxPrintPreferences", "BP");
            DropColumn("dbo.RxPrintPreferences", "ChiefComplainsWithHistory");
            DropColumn("dbo.RxPrintPreferences", "ChiefComplains");
        }
    }
}
