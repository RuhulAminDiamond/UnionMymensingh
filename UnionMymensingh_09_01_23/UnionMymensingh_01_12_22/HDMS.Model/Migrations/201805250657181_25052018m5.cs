namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25052018m5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "PhCompanies");
            RenameTable(name: "dbo.PhSuplierInfoes", newName: "SuplierInfoes");
            DropForeignKey("dbo.PhSupplierLedgers", "SupId", "dbo.PhSuplierInfoes");
            DropIndex("dbo.PhSupplierLedgers", new[] { "SupId" });
            CreateTable(
                "dbo.PhInvoiceDetails",
                c => new
                    {
                        InvoiceDetailId = c.Long(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailId)
                .ForeignKey("dbo.PhInvoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PhInvoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Invdate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TotalTK = c.Double(nullable: false),
                        DiscountTK = c.Double(nullable: false),
                        GrandTK = c.Double(nullable: false),
                        ReceivedTK = c.Double(nullable: false),
                        ChangeTK = c.Double(nullable: false),
                        DueTK = c.Double(nullable: false),
                        ReturnAdjustedTK = c.Double(nullable: false),
                        IsReturened = c.String(),
                        RRInvoice = c.Int(nullable: false),
                        ReturnedInvoiceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PhOrderDetails",
                c => new
                    {
                        OrderDetailId = c.Long(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.PhOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.PhOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderTo = c.Int(nullable: false),
                        OrderNo = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderYear = c.Int(nullable: false),
                        OrderMonth = c.Int(nullable: false),
                        OrderGenerateBy = c.Int(nullable: false),
                        OrderVerifiedBy = c.Int(nullable: false),
                        OrderApprovedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.PhReceiveDetails",
                c => new
                    {
                        ReceiveDetailId = c.Long(nullable: false, identity: true),
                        ReceivedId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiveDetailId)
                .ForeignKey("dbo.PhReceives", t => t.ReceivedId, cascadeDelete: true)
                .Index(t => t.ReceivedId);
            
            CreateTable(
                "dbo.PhReceives",
                c => new
                    {
                        ReceiveId = c.Long(nullable: false, identity: true),
                        RDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        TotalTk = c.Double(nullable: false),
                        DiscountTk = c.Double(nullable: false),
                        SupplerId = c.Int(nullable: false),
                        ReceiveInvoiceNo = c.Int(nullable: false),
                        SupInvNo = c.String(),
                        SupChalanNo = c.String(),
                        SupInvDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiveId);
            
            AddColumn("dbo.PhCompanies", "ShortName", c => c.String());
            AddColumn("dbo.PhCompanies", "Website", c => c.String());
            AddColumn("dbo.SupplierLedgers", "SuplierInfo_SupId", c => c.Int());
            CreateIndex("dbo.SupplierLedgers", "SuplierInfo_SupId");
            AddForeignKey("dbo.SupplierLedgers", "SuplierInfo_SupId", "dbo.SuplierInfoes", "SupId");
            DropTable("dbo.CustomerLedgers");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.ParentGroups");
            DropTable("dbo.PhSupplierLedgers");
            DropTable("dbo.PhVat");
            DropTable("dbo.Receives");
            DropTable("dbo.ReceiveDetails");
            DropTable("dbo.ReturnInvoiceDetails");
            DropTable("dbo.ReturnInvoices");
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Supplierid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Suppliername = c.String(),
                        Address = c.String(),
                        Contactno = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Supplierid);
            
            CreateTable(
                "dbo.ReturnInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnDate = c.DateTime(nullable: false),
                        SoldInvoice = c.Int(nullable: false),
                        ReturnAmount = c.Double(nullable: false),
                        AdjustableAmount = c.Double(nullable: false),
                        ReturnBy = c.String(),
                        IsAdjusted = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturnInvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnInvoice = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ReturnQty = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceiveDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceivedId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        TotalTk = c.Double(nullable: false),
                        DiscountTk = c.Double(nullable: false),
                        SupplerId = c.Int(nullable: false),
                        SChallanNo = c.String(),
                        SInvoiceNo = c.String(),
                        SInvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhVat",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VatInPercent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhSupplierLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SupId = c.Int(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Invdate = c.DateTime(nullable: false),
                        RegNo = c.Int(nullable: false),
                        AdmissionNo = c.Long(nullable: false),
                        RxId = c.Long(nullable: false),
                        TotalTK = c.Double(nullable: false),
                        DiscountTK = c.Double(nullable: false),
                        GrandTK = c.Double(nullable: false),
                        ReceivedTK = c.Double(nullable: false),
                        ChangeTK = c.Double(nullable: false),
                        DueTK = c.Double(nullable: false),
                        ReturnAdjustedTK = c.Double(nullable: false),
                        InvoiceNumber = c.String(),
                        ChallanNumber = c.String(),
                        ChallanAddress = c.String(),
                        InvoiceType = c.String(),
                        IsReturened = c.String(),
                        RRInvoice = c.Int(nullable: false),
                        ReturnedInvoiceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Trandate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SupplierLedgers", "SuplierInfo_SupId", "dbo.SuplierInfoes");
            DropForeignKey("dbo.PhReceiveDetails", "ReceivedId", "dbo.PhReceives");
            DropForeignKey("dbo.PhOrderDetails", "OrderId", "dbo.PhOrders");
            DropForeignKey("dbo.PhInvoiceDetails", "InvoiceId", "dbo.PhInvoices");
            DropIndex("dbo.SupplierLedgers", new[] { "SuplierInfo_SupId" });
            DropIndex("dbo.PhReceiveDetails", new[] { "ReceivedId" });
            DropIndex("dbo.PhOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.PhInvoiceDetails", new[] { "InvoiceId" });
            DropColumn("dbo.SupplierLedgers", "SuplierInfo_SupId");
            DropColumn("dbo.PhCompanies", "Website");
            DropColumn("dbo.PhCompanies", "ShortName");
            DropTable("dbo.PhReceives");
            DropTable("dbo.PhReceiveDetails");
            DropTable("dbo.PhOrders");
            DropTable("dbo.PhOrderDetails");
            DropTable("dbo.PhInvoices");
            DropTable("dbo.PhInvoiceDetails");
            CreateIndex("dbo.PhSupplierLedgers", "SupId");
            AddForeignKey("dbo.PhSupplierLedgers", "SupId", "dbo.PhSuplierInfoes", "SupId", cascadeDelete: true);
            RenameTable(name: "dbo.SuplierInfoes", newName: "PhSuplierInfoes");
            RenameTable(name: "dbo.PhCompanies", newName: "Customers");
        }
    }
}
