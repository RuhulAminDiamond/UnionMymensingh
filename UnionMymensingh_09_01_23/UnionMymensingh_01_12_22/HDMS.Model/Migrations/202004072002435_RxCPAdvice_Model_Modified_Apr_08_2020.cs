namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPAdvice_Model_Modified_Apr_08_2020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxCPAdvices", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxCPAdvices", new[] { "CPId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.RxCPAdvices", "CPId");
            AddForeignKey("dbo.RxCPAdvices", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
        }
    }
}
