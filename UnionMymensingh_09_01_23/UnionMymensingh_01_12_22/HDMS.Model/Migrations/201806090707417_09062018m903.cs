namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09062018m903 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HpPatientCurrentAccomodations", newName: "HpPatientAccomodationInfoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HpPatientAccomodationInfoes", newName: "HpPatientCurrentAccomodations");
        }
    }
}
