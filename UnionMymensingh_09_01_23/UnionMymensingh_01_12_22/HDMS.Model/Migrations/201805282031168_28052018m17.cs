namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "WardOrCabin", c => c.String());
            AddColumn("dbo.HospitalPatientInfoes", "WardOrCabinId", c => c.Int(nullable: false));
            DropColumn("dbo.HospitalPatientInfoes", "BedCabinNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "BedCabinNo", c => c.String());
            DropColumn("dbo.HospitalPatientInfoes", "WardOrCabinId");
            DropColumn("dbo.HospitalPatientInfoes", "WardOrCabin");
        }
    }
}
