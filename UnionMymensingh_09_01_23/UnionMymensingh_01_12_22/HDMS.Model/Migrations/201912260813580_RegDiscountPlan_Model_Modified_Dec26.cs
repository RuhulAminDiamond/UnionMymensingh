namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegDiscountPlan_Model_Modified_Dec26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegDiscountPlans", "VentilationDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.RegDiscountPlans", "OxygenDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.RegDiscountPlans", "PharmacyDiscount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegDiscountPlans", "PharmacyDiscount");
            DropColumn("dbo.RegDiscountPlans", "OxygenDiscount");
            DropColumn("dbo.RegDiscountPlans", "VentilationDiscount");
        }
    }
}
