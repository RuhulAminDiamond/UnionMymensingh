namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientsTable_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OTSchedules", "IndicationOfSurgery", c => c.String());
            AddColumn("dbo.OTSchedules", "IncisionType", c => c.String());
            AddColumn("dbo.OTSchedules", "AnaesthesiaType", c => c.String());
            AlterColumn("dbo.Patients", "DiscountCardNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DiscountCardNo", c => c.Long(nullable: false));
            DropColumn("dbo.OTSchedules", "AnaesthesiaType");
            DropColumn("dbo.OTSchedules", "IncisionType");
            DropColumn("dbo.OTSchedules", "IndicationOfSurgery");
        }
    }
}
