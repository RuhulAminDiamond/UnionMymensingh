namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ESignature_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportConsultants", "ESignature", c => c.Binary());
            AddColumn("dbo.ReportConsultants", "IsESignatureAllow", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportConsultants", "IsESignatureAllow");
            DropColumn("dbo.ReportConsultants", "ESignature");
        }
    }
}
