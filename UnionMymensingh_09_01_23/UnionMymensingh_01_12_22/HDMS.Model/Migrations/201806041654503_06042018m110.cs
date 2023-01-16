namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m110 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhReceiveDetail2",
                c => new
                    {
                        ReceiveDetailId = c.Long(nullable: false, identity: true),
                        ReceivedId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BatchNo = c.String(),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        disCountInpercent = c.Double(nullable: false),
                        grossDiscount = c.Double(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiveDetailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhReceiveDetail2");
        }
    }
}
