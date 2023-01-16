namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCpAdviceTemplateDetail_Model_Modified_May30_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", c => c.Int(nullable: false));
            CreateIndex("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId");
            AddForeignKey("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", "dbo.RxCPAdvices", "RxCpAdvId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", "dbo.RxCPAdvices");
            DropIndex("dbo.RxCpAdviceTemplateDetails", new[] { "RxCpAdvId" });
            DropColumn("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId");
        }
    }
}
