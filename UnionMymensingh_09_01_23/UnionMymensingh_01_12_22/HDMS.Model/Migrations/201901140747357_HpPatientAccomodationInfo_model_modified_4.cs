namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPatientAccomodationInfo_model_modified_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HpPatientAccomodationInfoes", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HpPatientAccomodationInfoes", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
