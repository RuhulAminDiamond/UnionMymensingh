namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16052018m6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Vat", newName: "PhVat");
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        FormationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FormationId);
            
            CreateTable(
                "dbo.Generics",
                c => new
                    {
                        GenericId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenericId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PhOrderInfoes",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderTo = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        GenerateBy = c.Int(nullable: false),
                        VerifiedBy = c.Int(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PhProductInfoes",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        BarCode = c.String(),
                        BrandName = c.String(),
                        SubGroupId = c.Int(nullable: false),
                        GenericId = c.Int(nullable: false),
                        FormationId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        Unit = c.String(),
                        PurchasePrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        Indication = c.String(),
                        DosageAdmistration = c.String(),
                        Preperation = c.String(),
                        SideEffact = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Formations", t => t.FormationId, cascadeDelete: true)
                .ForeignKey("dbo.Generics", t => t.GenericId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.PhSubGroups", t => t.SubGroupId, cascadeDelete: true)
                .Index(t => t.SubGroupId)
                .Index(t => t.GenericId)
                .Index(t => t.FormationId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PhSubGroups",
                c => new
                    {
                        SubGroupId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubGroupId)
                .ForeignKey("dbo.PhProductGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.PhProductGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.PhSuplierInfoes",
                c => new
                    {
                        SupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactPerson = c.String(),
                        CpMobileNo = c.String(),
                        CpEmail = c.String(),
                        CpStatus = c.String(),
                    })
                .PrimaryKey(t => t.SupId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhSuplierInfoes", t => t.SupId, cascadeDelete: true)
                .Index(t => t.SupId);
            
            CreateTable(
                "dbo.Strengths",
                c => new
                    {
                        StrengthId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StrengthId);
            
            DropTable("dbo.Groups");
            DropTable("dbo.ProductInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductInfoes",
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
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.PhSupplierLedgers", "SupId", "dbo.PhSuplierInfoes");
            DropForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.PhProductInfoes", "SubGroupId", "dbo.PhSubGroups");
            DropForeignKey("dbo.PhSubGroups", "GroupId", "dbo.PhProductGroups");
            DropForeignKey("dbo.PhProductInfoes", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhProductInfoes", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.PhProductInfoes", "FormationId", "dbo.Formations");
            DropIndex("dbo.PhSupplierLedgers", new[] { "SupId" });
            DropIndex("dbo.PhSubGroups", new[] { "GroupId" });
            DropIndex("dbo.PhProductInfoes", new[] { "ManufacturerId" });
            DropIndex("dbo.PhProductInfoes", new[] { "FormationId" });
            DropIndex("dbo.PhProductInfoes", new[] { "GenericId" });
            DropIndex("dbo.PhProductInfoes", new[] { "SubGroupId" });
            DropIndex("dbo.PhOrderInfoes", new[] { "ProductId" });
            DropTable("dbo.Strengths");
            DropTable("dbo.PhSupplierLedgers");
            DropTable("dbo.PhSuplierInfoes");
            DropTable("dbo.PhProductGroups");
            DropTable("dbo.PhSubGroups");
            DropTable("dbo.PhProductInfoes");
            DropTable("dbo.PhOrderInfoes");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Generics");
            DropTable("dbo.Formations");
            RenameTable(name: "dbo.PhVat", newName: "Vat");
        }
    }
}
