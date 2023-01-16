namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreatmentOnDischarge_Model_Modified_Sept_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TreatmentOnDischarges", "BeforAfterMeal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TreatmentOnDischarges", "BeforAfterMeal");
        }
    }
}
