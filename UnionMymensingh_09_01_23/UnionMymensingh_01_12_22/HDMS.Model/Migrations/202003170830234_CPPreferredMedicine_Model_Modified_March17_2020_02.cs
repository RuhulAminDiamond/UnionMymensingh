namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPPreferredMedicine_Model_Modified_March17_2020_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CPPreferredMedicines", "Qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CPPreferredMedicines", "Qty");
        }
    }
}
