namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DischargeTemplate_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DischargeTemplates",
                c => new
                    {
                        TId = c.Int(nullable: false, identity: true),
                        TGroup = c.String(),
                        FileName = c.String(),
                        TemplateName = c.String(),
                        TemplateContent = c.Binary(),
                    })
                .PrimaryKey(t => t.TId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DischargeTemplates");
        }
    }
}
