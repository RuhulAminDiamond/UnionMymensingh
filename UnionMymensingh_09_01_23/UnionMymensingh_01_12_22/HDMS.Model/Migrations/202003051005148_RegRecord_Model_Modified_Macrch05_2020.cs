namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegRecord_Model_Modified_Macrch05_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "District", c => c.String());
            AddColumn("dbo.RegRecords", "ArearOrThana", c => c.String());
            AddColumn("dbo.RegRecords", "PatientAddress", c => c.String());
            AddColumn("dbo.RegRecords", "CPDistrict", c => c.String());
            AddColumn("dbo.RegRecords", "CPArearOrThana", c => c.String());
            AddColumn("dbo.RegRecords", "CPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegRecords", "CPAddress");
            DropColumn("dbo.RegRecords", "CPArearOrThana");
            DropColumn("dbo.RegRecords", "CPDistrict");
            DropColumn("dbo.RegRecords", "PatientAddress");
            DropColumn("dbo.RegRecords", "ArearOrThana");
            DropColumn("dbo.RegRecords", "District");
        }
    }
}
