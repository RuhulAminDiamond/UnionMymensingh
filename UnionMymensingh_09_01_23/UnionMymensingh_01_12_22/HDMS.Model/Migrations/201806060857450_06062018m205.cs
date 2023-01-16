namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062018m205 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HospitalPatientInfoes", "WardOrCabin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "WardOrCabin", c => c.String());
        }
    }
}
