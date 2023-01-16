namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPPreferredMedicine_Model_Modified_Apr26_2020_01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCPPreferredMedicines", "BrandShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCPPreferredMedicines", "BrandShortName");
        }
    }
}
