namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m109 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Formations", t => t.FormationId, cascadeDelete: true)
                .ForeignKey("dbo.Generics", t => t.GenericId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.PhSubGroups", t => t.SubGroupId, cascadeDelete: true)
                .Index(t => t.SubGroupId)
                .Index(t => t.GenericId)
                .Index(t => t.FormationId)
                .Index(t => t.ManufacturerId);
            
            AddForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo2", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhProductInfo2", "SubGroupId", "dbo.PhSubGroups");
            DropForeignKey("dbo.PhOrderInfoes", "ProductId", "dbo.PhProductInfo2");
            DropForeignKey("dbo.PhProductInfo2", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhProductInfo2", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.PhProductInfo2", "FormationId", "dbo.Formations");
            DropIndex("dbo.PhProductInfo2", new[] { "ManufacturerId" });
            DropIndex("dbo.PhProductInfo2", new[] { "FormationId" });
            DropIndex("dbo.PhProductInfo2", new[] { "GenericId" });
            DropIndex("dbo.PhProductInfo2", new[] { "SubGroupId" });
            DropTable("dbo.PhProductInfo2");
        }
    }
}
