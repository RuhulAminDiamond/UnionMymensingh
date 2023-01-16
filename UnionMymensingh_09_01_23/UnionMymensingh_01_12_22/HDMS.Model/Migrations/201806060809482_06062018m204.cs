namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06062018m204 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PatientAccomodationTypes", newName: "HpPatientAccomodationTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HpPatientAccomodationTypes", newName: "PatientAccomodationTypes");
        }
    }
}
