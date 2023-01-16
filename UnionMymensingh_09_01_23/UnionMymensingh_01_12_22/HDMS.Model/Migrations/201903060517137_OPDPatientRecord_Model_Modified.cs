namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPDPatientRecord_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDPatientRecords", "GroupId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDPatientRecords", "GroupId");
        }
    }
}
