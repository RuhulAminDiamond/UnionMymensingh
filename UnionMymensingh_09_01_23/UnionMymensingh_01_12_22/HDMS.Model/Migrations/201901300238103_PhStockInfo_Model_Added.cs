namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhStockInfo_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhStockInfoes",
                c => new
                    {
                        StckId = c.Long(nullable: false, identity: true),
                        LotNo = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BatchNo = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        CurrentStock = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StckId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhStockInfoes");
        }
    }
}
