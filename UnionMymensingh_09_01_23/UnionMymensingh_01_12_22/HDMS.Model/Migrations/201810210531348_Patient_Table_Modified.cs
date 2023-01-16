namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patient_Table_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DiscountCardNo", c => c.Long(nullable: false));
            AddColumn("dbo.Patients", "DiscountHonouredInPercentAgainstCardNo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DiscountHonouredInPercentAgainstCardNo");
            DropColumn("dbo.Patients", "DiscountCardNo");
        }
    }
}
