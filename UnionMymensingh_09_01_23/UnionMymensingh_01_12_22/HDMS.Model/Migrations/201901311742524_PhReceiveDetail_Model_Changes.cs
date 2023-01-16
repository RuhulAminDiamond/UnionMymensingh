namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhReceiveDetail_Model_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhReceiveDetails", "LotNo", c => c.Long(nullable: false));
            CreateIndex("dbo.PhReceiveDetails", "LotNo");
            CreateIndex("dbo.PhReceiveDetails", "ProductId");
            AddForeignKey("dbo.PhReceiveDetails", "LotNo", "dbo.PhLotInfoes", "LotNo", cascadeDelete: true);
            AddForeignKey("dbo.PhReceiveDetails", "ProductId", "dbo.PhProductInfoes", "ProductId", cascadeDelete: true);
            DropColumn("dbo.PhReceiveDetails", "BatchNo");
            DropColumn("dbo.PhReceiveDetails", "ExpireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhReceiveDetails", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhReceiveDetails", "BatchNo", c => c.String());
            DropForeignKey("dbo.PhReceiveDetails", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.PhReceiveDetails", "LotNo", "dbo.PhLotInfoes");
            DropIndex("dbo.PhReceiveDetails", new[] { "ProductId" });
            DropIndex("dbo.PhReceiveDetails", new[] { "LotNo" });
            DropColumn("dbo.PhReceiveDetails", "LotNo");
        }
    }
}
