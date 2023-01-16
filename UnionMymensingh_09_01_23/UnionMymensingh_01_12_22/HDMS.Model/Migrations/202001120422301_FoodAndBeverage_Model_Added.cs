namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodAndBeverage_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodAndBeverageDepts",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IndentUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.FoodAndBeverageGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MasterGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.FoodAndBeverageMasterGroups", t => t.MasterGroupId, cascadeDelete: true)
                .Index(t => t.MasterGroupId);
            
            CreateTable(
                "dbo.FoodAndBeverageMasterGroups",
                c => new
                    {
                        MasterGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MasterGroupId);
            
            CreateTable(
                "dbo.FoodAndBeverageInvoiceDetails",
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
                .ForeignKey("dbo.FoodAndBeverageInvoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.FoodAndBeverageProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.FoodAndBeverageInvoices",
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
                        RequisitionId = c.Long(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.FoodAndBeverageProductInfoes",
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
                .ForeignKey("dbo.FoodAndBeverageGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.FoodAndBeverageItemUsesMasters",
                c => new
                    {
                        FBMId = c.Long(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        BillNo = c.Long(nullable: false),
                        UDate = c.DateTime(nullable: false),
                        UTime = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FBMId);
            
            CreateTable(
                "dbo.FoodAndBeverageReceiveDetails",
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
                .ForeignKey("dbo.FoodAndBeverageProductInfoes", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.FoodAndBeverageReceives", t => t.ReceiveId, cascadeDelete: true)
                .Index(t => t.ReceiveId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.FoodAndBeverageReceives",
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
                "dbo.FoodAndBeverageRequisitions",
                c => new
                    {
                        RequisitionId = c.Long(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        RDate = c.DateTime(nullable: false),
                        RTime = c.String(),
                        OperateBy = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequisitionId)
                .ForeignKey("dbo.FoodAndBeverageDepts", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.PhTemIPDReturnLadgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        RetIndentId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        TransactionTime = c.String(),
                        AdmissionId = c.Long(nullable: false),
                        ReturnAmount = c.Double(nullable: false),
                        DiscountAdjusted = c.Double(nullable: false),
                        Returnable = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TranId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodAndBeverageRequisitions", "DeptId", "dbo.FoodAndBeverageDepts");
            DropForeignKey("dbo.FoodAndBeverageReceiveDetails", "ReceiveId", "dbo.FoodAndBeverageReceives");
            DropForeignKey("dbo.FoodAndBeverageReceiveDetails", "ProductId", "dbo.FoodAndBeverageProductInfoes");
            DropForeignKey("dbo.FoodAndBeverageInvoiceDetails", "ProductId", "dbo.FoodAndBeverageProductInfoes");
            DropForeignKey("dbo.FoodAndBeverageProductInfoes", "GroupId", "dbo.FoodAndBeverageGroups");
            DropForeignKey("dbo.FoodAndBeverageInvoiceDetails", "InvoiceId", "dbo.FoodAndBeverageInvoices");
            DropForeignKey("dbo.FoodAndBeverageGroups", "MasterGroupId", "dbo.FoodAndBeverageMasterGroups");
            DropIndex("dbo.FoodAndBeverageRequisitions", new[] { "DeptId" });
            DropIndex("dbo.FoodAndBeverageReceiveDetails", new[] { "ProductId" });
            DropIndex("dbo.FoodAndBeverageReceiveDetails", new[] { "ReceiveId" });
            DropIndex("dbo.FoodAndBeverageProductInfoes", new[] { "GroupId" });
            DropIndex("dbo.FoodAndBeverageInvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.FoodAndBeverageInvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.FoodAndBeverageGroups", new[] { "MasterGroupId" });
            DropTable("dbo.PhTemIPDReturnLadgers");
            DropTable("dbo.FoodAndBeverageRequisitions");
            DropTable("dbo.FoodAndBeverageReceives");
            DropTable("dbo.FoodAndBeverageReceiveDetails");
            DropTable("dbo.FoodAndBeverageItemUsesMasters");
            DropTable("dbo.FoodAndBeverageProductInfoes");
            DropTable("dbo.FoodAndBeverageInvoices");
            DropTable("dbo.FoodAndBeverageInvoiceDetails");
            DropTable("dbo.FoodAndBeverageMasterGroups");
            DropTable("dbo.FoodAndBeverageGroups");
            DropTable("dbo.FoodAndBeverageDepts");
        }
    }
}
