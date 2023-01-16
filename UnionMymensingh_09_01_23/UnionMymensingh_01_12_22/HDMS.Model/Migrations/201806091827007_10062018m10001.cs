namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10062018m10001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPatientAccomodationInfoes", "AllotType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpPatientAccomodationInfoes", "AllotType");
        }
    }
}
