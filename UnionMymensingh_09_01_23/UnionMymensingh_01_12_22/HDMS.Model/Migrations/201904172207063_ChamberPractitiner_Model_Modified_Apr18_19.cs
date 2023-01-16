namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChamberPractitiner_Model_Modified_Apr18_19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChamberPractitioners", "PatientQuota", c => c.Int(nullable: false));
            AddColumn("dbo.ChamberPractitioners", "OffDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChamberPractitioners", "OffDay");
            DropColumn("dbo.ChamberPractitioners", "PatientQuota");
        }
    }
}
