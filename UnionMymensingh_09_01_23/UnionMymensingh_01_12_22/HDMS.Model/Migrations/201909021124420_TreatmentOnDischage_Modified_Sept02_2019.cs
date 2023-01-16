namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreatmentOnDischage_Modified_Sept02_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TreatmentOnDischarges", "IsDoseBanglaFont", c => c.Boolean(nullable: false));
            AddColumn("dbo.TreatmentOnDischarges", "IsDurationBanglaFont", c => c.Boolean(nullable: false));
            AddColumn("dbo.TreatmentOnDischarges", "IsBeforAfterMealBanglaFont", c => c.Boolean(nullable: false));
            AddColumn("dbo.TreatmentOnDischarges", "IsUnitBanglaFont", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TreatmentOnDischarges", "IsUnitBanglaFont");
            DropColumn("dbo.TreatmentOnDischarges", "IsBeforAfterMealBanglaFont");
            DropColumn("dbo.TreatmentOnDischarges", "IsDurationBanglaFont");
            DropColumn("dbo.TreatmentOnDischarges", "IsDoseBanglaFont");
        }
    }
}
