namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPatientAccomodationType_Model_Modified_Feb03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPatientAccomodationTypes", "ServiceHeadId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpPatientAccomodationTypes", "ServiceHeadId");
        }
    }
}
