namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPAdvice_Model_Modified_Apr_11_2020 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.RxCPAdvices");
            AddColumn("dbo.RxAdviceToPatients", "RxCpAdvId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPAdvices", "RxCpAdvId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RxCPAdvices", "RxCpAdvId");
            CreateIndex("dbo.RxAdviceToPatients", "RxCpAdvId");
            AddForeignKey("dbo.RxAdviceToPatients", "RxCpAdvId", "dbo.RxCPAdvices", "RxCpAdvId", cascadeDelete: true);
            DropColumn("dbo.RxCPAdvices", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxCPAdvices", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RxAdviceToPatients", "RxCpAdvId", "dbo.RxCPAdvices");
            DropIndex("dbo.RxAdviceToPatients", new[] { "RxCpAdvId" });
            DropPrimaryKey("dbo.RxCPAdvices");
            DropColumn("dbo.RxCPAdvices", "RxCpAdvId");
            DropColumn("dbo.RxAdviceToPatients", "RxCpAdvId");
            AddPrimaryKey("dbo.RxCPAdvices", "Id");
        }
    }
}
