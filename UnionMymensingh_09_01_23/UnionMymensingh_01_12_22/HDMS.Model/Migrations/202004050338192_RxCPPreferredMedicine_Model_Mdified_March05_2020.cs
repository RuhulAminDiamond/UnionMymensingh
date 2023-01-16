namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPPreferredMedicine_Model_Mdified_March05_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCPPreferredMedicines", "FormationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCPPreferredMedicines", "FormationId");
        }
    }
}
