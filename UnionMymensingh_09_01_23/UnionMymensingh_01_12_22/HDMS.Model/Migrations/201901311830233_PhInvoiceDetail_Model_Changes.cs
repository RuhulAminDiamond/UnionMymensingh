namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhInvoiceDetail_Model_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoiceDetails", "LotNo", c => c.Long(nullable: false));
            CreateIndex("dbo.PhInvoiceDetails", "LotNo");
            CreateIndex("dbo.PhInvoiceDetails", "ProductId");
          //  AddForeignKey("dbo.PhInvoiceDetails", "LotNo", "dbo.PhLotInfoes", "LotNo", cascadeDelete: true);
            AddForeignKey("dbo.PhInvoiceDetails", "ProductId", "dbo.PhProductInfoes", "ProductId", cascadeDelete: true);
            DropColumn("dbo.PhInvoiceDetails", "BatchNo");
            DropColumn("dbo.PhInvoiceDetails", "ExpireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhInvoiceDetails", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhInvoiceDetails", "BatchNo", c => c.String());
            DropForeignKey("dbo.PhInvoiceDetails", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.PhInvoiceDetails", "LotNo", "dbo.PhLotInfoes");
            DropIndex("dbo.PhInvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.PhInvoiceDetails", new[] { "LotNo" });
            DropColumn("dbo.PhInvoiceDetails", "LotNo");
        }
    }
}
