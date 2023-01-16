namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargeCertificateMasters", "DischargeTime", c => c.String());
            AddColumn("dbo.DischargeCertificateMasters", "CertificateBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DischargeCertificateMasters", "CertificateBy");
            DropColumn("dbo.DischargeCertificateMasters", "DischargeTime");
        }
    }
}
