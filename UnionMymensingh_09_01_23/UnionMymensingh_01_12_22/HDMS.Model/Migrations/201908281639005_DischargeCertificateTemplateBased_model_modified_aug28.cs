namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DischargeCertificateTemplateBased_model_modified_aug28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargeCertificateTemplateBaseds", "BillNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DischargeCertificateTemplateBaseds", "BillNo");
        }
    }
}
