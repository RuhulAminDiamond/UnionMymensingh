namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store_Model_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StoreProducts", "SPGId", "dbo.StoreProductSubGroups");
            DropForeignKey("dbo.StoreProductSubGroups", "MGId", "dbo.StoreProductMasterGroups");
            DropIndex("dbo.StoreProductSubGroups", new[] { "MGId" });
            DropIndex("dbo.StoreProducts", new[] { "SPGId" });
            RenameColumn(table: "dbo.SupplierLedgers", name: "SupId", newName: "SupplierId");
            RenameIndex(table: "dbo.SupplierLedgers", name: "IX_SupId", newName: "IX_SupplierId");
            CreateTable(
                "dbo.StoreGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoreMasterGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.StoreMasterGroups", t => t.StoreMasterGroupId, cascadeDelete: true)
                .Index(t => t.StoreMasterGroupId);
            
            CreateTable(
                "dbo.StoreMasterGroups",
                c => new
                    {
                        StoreMasterGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StoreMasterGroupId);
            
            CreateTable(
                "dbo.StoreInvoiceDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InvoiceId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreInvoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.StoreProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreInvoices",
                c => new
                    {
                        InvoiceId = c.Long(nullable: false, identity: true),
                        Invdate = c.DateTime(nullable: false),
                        MobileNo = c.String(),
                        TotalTK = c.Double(nullable: false),
                        DiscountTK = c.Double(nullable: false),
                        GrandTK = c.Double(nullable: false),
                        ReceivedTK = c.Double(nullable: false),
                        ChangeTK = c.Double(nullable: false),
                        OrderFrom = c.Int(nullable: false),
                        DueTK = c.Double(nullable: false),
                        ReturnAdjustedTK = c.Double(nullable: false),
                        InvoiceNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ChallanNumber = c.String(),
                        ChallanAddress = c.String(),
                        InvoiceType = c.String(),
                        IsReturened = c.String(),
                        RRInvoice = c.Int(nullable: false),
                        ReturnedInvoiceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.StoreProductInfoes",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Name = c.String(),
                        GroupId = c.Int(nullable: false),
                        Unit = c.String(),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        WholeSaleRate = c.Double(nullable: false),
                        ROL = c.Int(nullable: false),
                        QtyPerCartoonOrBox = c.Int(nullable: false),
                        DebitAccId = c.Int(nullable: false),
                        CreditAccId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.StoreGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.StoreReceiveDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceiveId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreProductInfoes", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.StoreReceives", t => t.ReceiveId, cascadeDelete: true)
                .Index(t => t.ReceiveId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreReceives",
                c => new
                    {
                        ReceiveId = c.Long(nullable: false, identity: true),
                        RDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        TotalTk = c.Double(nullable: false),
                        DiscountTk = c.Double(nullable: false),
                        PaidTk = c.Double(nullable: false),
                        SupplerId = c.Int(nullable: false),
                        SChallanNo = c.String(),
                        SInvoiceNo = c.String(),
                        SInvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiveId);
            
            CreateTable(
                "dbo.SupplierInfoes",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactPerson = c.String(),
                        CpMobileNo = c.String(),
                        CpEmail = c.String(),
                        Category = c.String(),
                        CpStatus = c.String(),
                        SupAccId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            DropTable("dbo.StoreProductMasterGroups");
            DropTable("dbo.StoreProductSubGroups");
            DropTable("dbo.StoreProducts");
            DropTable("dbo.SuplierInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SuplierInfoes",
                c => new
                    {
                        SupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactPerson = c.String(),
                        CpMobileNo = c.String(),
                        CpEmail = c.String(),
                        Category = c.String(),
                        CpStatus = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupId);
            
            CreateTable(
                "dbo.StoreProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SPGId = c.Int(nullable: false),
                        Name = c.String(),
                        Unit = c.String(),
                        PurchaseRate = c.Double(nullable: false),
                        ROL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreProductSubGroups",
                c => new
                    {
                        SPGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MGId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SPGId);
            
            CreateTable(
                "dbo.StoreProductMasterGroups",
                c => new
                    {
                        MGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MGId);
            
            DropForeignKey("dbo.StoreReceiveDetails", "ReceiveId", "dbo.StoreReceives");
            DropForeignKey("dbo.StoreReceiveDetails", "ProductId", "dbo.StoreProductInfoes");
            DropForeignKey("dbo.StoreInvoiceDetails", "ProductId", "dbo.StoreProductInfoes");
            DropForeignKey("dbo.StoreProductInfoes", "GroupId", "dbo.StoreGroups");
            DropForeignKey("dbo.StoreInvoiceDetails", "InvoiceId", "dbo.StoreInvoices");
            DropForeignKey("dbo.StoreGroups", "StoreMasterGroupId", "dbo.StoreMasterGroups");
            DropIndex("dbo.StoreReceiveDetails", new[] { "ProductId" });
            DropIndex("dbo.StoreReceiveDetails", new[] { "ReceiveId" });
            DropIndex("dbo.StoreProductInfoes", new[] { "GroupId" });
            DropIndex("dbo.StoreInvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.StoreInvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.StoreGroups", new[] { "StoreMasterGroupId" });
            DropTable("dbo.SupplierInfoes");
            DropTable("dbo.StoreReceives");
            DropTable("dbo.StoreReceiveDetails");
            DropTable("dbo.StoreProductInfoes");
            DropTable("dbo.StoreInvoices");
            DropTable("dbo.StoreInvoiceDetails");
            DropTable("dbo.StoreMasterGroups");
            DropTable("dbo.StoreGroups");
            RenameIndex(table: "dbo.SupplierLedgers", name: "IX_SupplierId", newName: "IX_SupId");
            RenameColumn(table: "dbo.SupplierLedgers", name: "SupplierId", newName: "SupId");
            CreateIndex("dbo.StoreProducts", "SPGId");
            CreateIndex("dbo.StoreProductSubGroups", "MGId");
            AddForeignKey("dbo.StoreProductSubGroups", "MGId", "dbo.StoreProductMasterGroups", "MGId", cascadeDelete: true);
            AddForeignKey("dbo.StoreProducts", "SPGId", "dbo.StoreProductSubGroups", "SPGId", cascadeDelete: true);
        }
    }
}
