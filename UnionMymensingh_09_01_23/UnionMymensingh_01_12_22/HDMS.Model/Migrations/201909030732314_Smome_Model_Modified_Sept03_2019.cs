namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Smome_Model_Modified_Sept03_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargeCertificateTemplateBaseds", "CabinNo", c => c.String());
            AddColumn("dbo.TEMP_LIS_ResultRecord", "ResultProducedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TEMP_LIS_ResultRecord", "ResultProducedBy");
            DropColumn("dbo.DischargeCertificateTemplateBaseds", "CabinNo");
        }
    }
}
