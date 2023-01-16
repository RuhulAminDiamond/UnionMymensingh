namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPPreferredMedicine_Model_Modified_March17_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CPPreferredMedicines", "DoseShortEn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "DoseShortBn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "DoseLongEn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "DoseLongBn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "BeforeAfterEn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "BeforeAfterBn", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "Duration", c => c.String());
            AddColumn("dbo.CPPreferredMedicines", "DurationUnit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CPPreferredMedicines", "DurationUnit");
            DropColumn("dbo.CPPreferredMedicines", "Duration");
            DropColumn("dbo.CPPreferredMedicines", "BeforeAfterBn");
            DropColumn("dbo.CPPreferredMedicines", "BeforeAfterEn");
            DropColumn("dbo.CPPreferredMedicines", "DoseLongBn");
            DropColumn("dbo.CPPreferredMedicines", "DoseLongEn");
            DropColumn("dbo.CPPreferredMedicines", "DoseShortBn");
            DropColumn("dbo.CPPreferredMedicines", "DoseShortEn");
        }
    }
}
