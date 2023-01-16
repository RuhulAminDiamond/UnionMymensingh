namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07052018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "SelfDiscountAllowed", c => c.Double(nullable: false));
            AddColumn("dbo.Doctor", "IsSelfFullFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctor", "RequestedPatientDiscountAdjustFromRefDoctor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "RequestedPatientDiscountAdjustFromRefDoctor");
            DropColumn("dbo.Doctor", "IsSelfFullFree");
            DropColumn("dbo.Doctor", "SelfDiscountAllowed");
            DropColumn("dbo.Doctor", "CategoryId");
        }
    }
}
