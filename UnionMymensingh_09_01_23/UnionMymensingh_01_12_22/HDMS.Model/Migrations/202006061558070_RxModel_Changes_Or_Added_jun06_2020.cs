namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Changes_Or_Added_jun06_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxPersonalPreferenceSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        IsDefaultDoseInEnglish = c.Boolean(nullable: false),
                        IsDefaultDoseInShortForm = c.Boolean(nullable: false),
                        IsDefaultAdviceInEnglish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.RxPrintPreferences", "AdvicesEnLanguage");
            DropColumn("dbo.RxPrintPreferences", "DoseShortDescription");
            DropColumn("dbo.RxPrintPreferences", "DoseEnLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPrintPreferences", "DoseEnLanguage", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "DoseShortDescription", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxPrintPreferences", "AdvicesEnLanguage", c => c.Boolean(nullable: false));
            DropTable("dbo.RxPersonalPreferenceSettings");
        }
    }
}
