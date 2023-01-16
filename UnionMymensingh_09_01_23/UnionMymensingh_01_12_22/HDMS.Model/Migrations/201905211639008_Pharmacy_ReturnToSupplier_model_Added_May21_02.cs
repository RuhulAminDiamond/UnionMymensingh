namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pharmacy_ReturnToSupplier_model_Added_May21_02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhReturnToSuppliers",
                c => new
                    {
                        RetId = c.Long(nullable: false, identity: true),
                        RetDate = c.DateTime(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        Remarks = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.RetId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PhSupplierReturnDetails",
                c => new
                    {
                        RetDId = c.Long(nullable: false, identity: true),
                        RetId = c.Long(nullable: false),
                        Lotno = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RetDId)
                .ForeignKey("dbo.PhReturnToSuppliers", t => t.RetId, cascadeDelete: true)
                .Index(t => t.RetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhSupplierReturnDetails", "RetId", "dbo.PhReturnToSuppliers");
            DropForeignKey("dbo.PhReturnToSuppliers", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.PhSupplierReturnDetails", new[] { "RetId" });
            DropIndex("dbo.PhReturnToSuppliers", new[] { "ManufacturerId" });
            DropTable("dbo.PhSupplierReturnDetails");
            DropTable("dbo.PhReturnToSuppliers");
        }
    }
}
