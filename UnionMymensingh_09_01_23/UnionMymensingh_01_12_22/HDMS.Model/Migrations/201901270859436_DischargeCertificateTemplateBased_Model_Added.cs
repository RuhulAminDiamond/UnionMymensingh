namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DischargeCertificateTemplateBased_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DischargeCertificateTemplateBaseds",
                c => new
                    {
                        DId = c.Long(nullable: false, identity: true),
                        RCId = c.Int(nullable: false),
                        DCPrintDate = c.DateTime(nullable: false),
                        DCPrintTime = c.String(),
                        DCContent = c.Binary(),
                    })
                .PrimaryKey(t => t.DId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DischargeCertificateTemplateBaseds");
        }
    }
}
