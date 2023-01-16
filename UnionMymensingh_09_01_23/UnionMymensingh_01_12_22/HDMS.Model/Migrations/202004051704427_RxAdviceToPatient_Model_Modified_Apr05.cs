namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxAdviceToPatient_Model_Modified_Apr05 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.RxAdviceToPatients");
            AddColumn("dbo.RxAdviceToPatients", "AdvId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RxAdviceToPatients", "RxVisitId", c => c.Long(nullable: false));
            AddColumn("dbo.RxAdviceToPatients", "Advice", c => c.String());
            AddPrimaryKey("dbo.RxAdviceToPatients", "AdvId");
            CreateIndex("dbo.RxAdviceToPatients", "RxVisitId");
            AddForeignKey("dbo.RxAdviceToPatients", "RxVisitId", "dbo.RxVisitHistories", "RxVisitId", cascadeDelete: true);
            DropColumn("dbo.RxAdviceToPatients", "Id");
            DropColumn("dbo.RxAdviceToPatients", "AdviceId");
            DropColumn("dbo.RxAdviceToPatients", "RxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxAdviceToPatients", "RxId", c => c.Long(nullable: false));
            AddColumn("dbo.RxAdviceToPatients", "AdviceId", c => c.Int(nullable: false));
            AddColumn("dbo.RxAdviceToPatients", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RxAdviceToPatients", "RxVisitId", "dbo.RxVisitHistories");
            DropIndex("dbo.RxAdviceToPatients", new[] { "RxVisitId" });
            DropPrimaryKey("dbo.RxAdviceToPatients");
            DropColumn("dbo.RxAdviceToPatients", "Advice");
            DropColumn("dbo.RxAdviceToPatients", "RxVisitId");
            DropColumn("dbo.RxAdviceToPatients", "AdvId");
            AddPrimaryKey("dbo.RxAdviceToPatients", "Id");
        }
    }
}
