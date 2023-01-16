namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Discharge_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargeCertificateDetails", "DescriptionLabel", c => c.String());
            AddColumn("dbo.DischargeCertificateDetails", "IsLabelBold", c => c.Int(nullable: false));
            DropColumn("dbo.DischargeCertificateDetails", "DescriptionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DischargeCertificateDetails", "DescriptionType", c => c.String());
            DropColumn("dbo.DischargeCertificateDetails", "IsLabelBold");
            DropColumn("dbo.DischargeCertificateDetails", "DescriptionLabel");
        }
    }
}
