namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m111 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ProductId)
               // .ForeignKey("dbo.Formations", t => t.FormationId, cascadeDelete: true)
               // .ForeignKey("dbo.Generics", t => t.GenericId, cascadeDelete: true)
               // .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
               /// .ForeignKey("dbo.PhSubGroups", t => t.SubGroupId, cascadeDelete: true)
                .Index(t => t.SubGroupId)
                .Index(t => t.GenericId)
                .Index(t => t.FormationId)
                .Index(t => t.ManufacturerId);
            
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
            
            AddForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo3", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhProductInfo3", "SubGroupId", "dbo.PhSubGroups");
            DropForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo3");
            DropForeignKey("dbo.PhProductInfo3", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhProductInfo3", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.PhProductInfo3", "FormationId", "dbo.Formations");
            DropIndex("dbo.PhProductInfo3", new[] { "ManufacturerId" });
            DropIndex("dbo.PhProductInfo3", new[] { "FormationId" });
            DropIndex("dbo.PhProductInfo3", new[] { "GenericId" });
            DropIndex("dbo.PhProductInfo3", new[] { "SubGroupId" });
            DropTable("dbo.PhReceiveDetail3");
            DropTable("dbo.PhProductInfo3");
        }
    }
}
