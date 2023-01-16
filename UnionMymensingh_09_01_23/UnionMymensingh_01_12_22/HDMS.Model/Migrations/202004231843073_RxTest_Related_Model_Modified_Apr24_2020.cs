namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxTest_Related_Model_Modified_Apr24_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxCPTestTemplateDetails", "TestId", "dbo.TestItems");
            DropIndex("dbo.RxCPTestTemplateDetails", new[] { "TestId" });
            AddColumn("dbo.RxCPTestTemplateDetails", "CPPTId", c => c.Long(nullable: false));
            AddColumn("dbo.RxTests", "CPPTId", c => c.Long(nullable: false));
            CreateIndex("dbo.RxCPTestTemplateDetails", "CPPTId");
           // AddForeignKey("dbo.RxCPTestTemplateDetails", "CPPTId", "dbo.RxCPPreferredTests", "CPPTId", cascadeDelete: true);
            DropColumn("dbo.RxCPTestTemplateDetails", "TestId");
            DropColumn("dbo.RxTests", "TestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxTests", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPTestTemplateDetails", "TestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RxCPTestTemplateDetails", "CPPTId", "dbo.RxCPPreferredTests");
            DropIndex("dbo.RxCPTestTemplateDetails", new[] { "CPPTId" });
            DropColumn("dbo.RxTests", "CPPTId");
            DropColumn("dbo.RxCPTestTemplateDetails", "CPPTId");
            CreateIndex("dbo.RxCPTestTemplateDetails", "TestId");
            AddForeignKey("dbo.RxCPTestTemplateDetails", "TestId", "dbo.TestItems", "TestId", cascadeDelete: true);
        }
    }
}
