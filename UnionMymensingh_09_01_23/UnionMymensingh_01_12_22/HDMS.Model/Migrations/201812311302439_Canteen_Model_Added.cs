namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Canteen_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CantGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CantInvoiceDetails",
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CantInvoices",
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
                        RRInvoice = c.Long(nullable: false),
                        ReturnedInvoiceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.CantMemberInfoes",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        CareOf = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.CantMemberLedgers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Trandate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CantProductInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Name = c.String(),
                        GroupId = c.Int(nullable: false),
                        Unit = c.String(),
                        PurchaseRate = c.Double(nullable: false),
                        SaleRate = c.Double(nullable: false),
                        WholeSaleRate = c.Double(nullable: false),
                        ROL = c.Int(nullable: false),
                        QtyPerCartoonOrBox = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CantReceives",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
                "dbo.CantReceiveDetails",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.CantReceiveDetails");
            DropTable("dbo.CantReceives");
            DropTable("dbo.CantProductInfoes");
            DropTable("dbo.CantMemberLedgers");
            DropTable("dbo.CantMemberInfoes");
            DropTable("dbo.CantInvoices");
            DropTable("dbo.CantInvoiceDetails");
            DropTable("dbo.CantGroups");
        }
    }
}
