namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModels_Modified_Feb28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxDrugs", "RxVisitId", c => c.Long(nullable: false));
            AddColumn("dbo.RxDrugs", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.RxTests", "RxVisitId", c => c.Long(nullable: false));
            AddColumn("dbo.RxTests", "discountInPercent", c => c.Int(nullable: false));
            AddColumn("dbo.RxTests", "discountGross", c => c.Int(nullable: false));
            CreateIndex("dbo.RxDrugs", "RxVisitId");
            CreateIndex("dbo.RxTests", "RxVisitId");
            AddForeignKey("dbo.RxDrugs", "RxVisitId", "dbo.RxVisitHistories", "RxVisitId", cascadeDelete: true);
            AddForeignKey("dbo.RxTests", "RxVisitId", "dbo.RxVisitHistories", "RxVisitId", cascadeDelete: true);
            DropColumn("dbo.RxDrugs", "RxId");
            DropColumn("dbo.RxTests", "RxInitDId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxTests", "RxInitDId", c => c.Long(nullable: false));
            AddColumn("dbo.RxDrugs", "RxId", c => c.Long(nullable: false));
            DropForeignKey("dbo.RxTests", "RxVisitId", "dbo.RxVisitHistories");
            DropForeignKey("dbo.RxDrugs", "RxVisitId", "dbo.RxVisitHistories");
            DropIndex("dbo.RxTests", new[] { "RxVisitId" });
            DropIndex("dbo.RxDrugs", new[] { "RxVisitId" });
            DropColumn("dbo.RxTests", "discountGross");
            DropColumn("dbo.RxTests", "discountInPercent");
            DropColumn("dbo.RxTests", "RxVisitId");
            DropColumn("dbo.RxDrugs", "Qty");
            DropColumn("dbo.RxDrugs", "RxVisitId");
        }
    }
}
