namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06052018131 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhProductInfo2", "FormationId", "dbo.Formations");
            DropForeignKey("dbo.PhProductInfo2", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.PhProductInfo2", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo2");
            DropForeignKey("dbo.PhProductInfo2", "SubGroupId", "dbo.PhSubGroups");
            DropForeignKey("dbo.PhProductInfo3", "FormationId", "dbo.Formations");
            DropForeignKey("dbo.PhProductInfo3", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.PhProductInfo3", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo3");
            DropForeignKey("dbo.PhProductInfo3", "SubGroupId", "dbo.PhSubGroups");
            DropIndex("dbo.PhProductInfo2", new[] { "SubGroupId" });
            DropIndex("dbo.PhProductInfo2", new[] { "GenericId" });
            DropIndex("dbo.PhProductInfo2", new[] { "FormationId" });
            DropIndex("dbo.PhProductInfo2", new[] { "ManufacturerId" });
            DropIndex("dbo.PhProductInfo3", new[] { "SubGroupId" });
            DropIndex("dbo.PhProductInfo3", new[] { "GenericId" });
            DropIndex("dbo.PhProductInfo3", new[] { "FormationId" });
            DropIndex("dbo.PhProductInfo3", new[] { "ManufacturerId" });
            DropTable("dbo.PhProductInfo2");
            DropTable("dbo.PhProductInfo3");
            DropTable("dbo.PhReceiveDetail2");
            DropTable("dbo.PhReceiveDetail3");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhReceiveDetail3",
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
            
            CreateTable(
                "dbo.PhProductInfo3",
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
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.PhProductInfo2",
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
                .PrimaryKey(t => t.ProductId);
            
            CreateIndex("dbo.PhProductInfo3", "ManufacturerId");
            CreateIndex("dbo.PhProductInfo3", "FormationId");
            CreateIndex("dbo.PhProductInfo3", "GenericId");
            CreateIndex("dbo.PhProductInfo3", "SubGroupId");
            CreateIndex("dbo.PhProductInfo2", "ManufacturerId");
            CreateIndex("dbo.PhProductInfo2", "FormationId");
            CreateIndex("dbo.PhProductInfo2", "GenericId");
            CreateIndex("dbo.PhProductInfo2", "SubGroupId");
            AddForeignKey("dbo.PhProductInfo3", "SubGroupId", "dbo.PhSubGroups", "SubGroupId", cascadeDelete: true);
            AddForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo3", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo3", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo3", "GenericId", "dbo.Generics", "GenericId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo3", "FormationId", "dbo.Formations", "FormationId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo2", "SubGroupId", "dbo.PhSubGroups", "SubGroupId", cascadeDelete: true);
            AddForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo2", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo2", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo2", "GenericId", "dbo.Generics", "GenericId", cascadeDelete: true);
            AddForeignKey("dbo.PhProductInfo2", "FormationId", "dbo.Formations", "FormationId", cascadeDelete: true);
        }
    }
}
