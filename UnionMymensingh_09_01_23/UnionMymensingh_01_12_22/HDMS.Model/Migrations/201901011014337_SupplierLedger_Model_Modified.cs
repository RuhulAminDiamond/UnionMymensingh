namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierLedger_Model_Modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SupplierLedgers", "SuplierInfo_SupId", "dbo.SuplierInfoes");
            DropIndex("dbo.SupplierLedgers", new[] { "SuplierInfo_SupId" });
            RenameColumn(table: "dbo.SupplierLedgers", name: "SuplierInfo_SupId", newName: "SupId");
            AlterColumn("dbo.SupplierLedgers", "SupId", c => c.Int(nullable: false));
            CreateIndex("dbo.SupplierLedgers", "SupId");
            AddForeignKey("dbo.SupplierLedgers", "SupId", "dbo.SuplierInfoes", "SupId", cascadeDelete: true);
            DropColumn("dbo.SupplierLedgers", "SupplierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SupplierLedgers", "SupplierId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SupplierLedgers", "SupId", "dbo.SuplierInfoes");
            DropIndex("dbo.SupplierLedgers", new[] { "SupId" });
            AlterColumn("dbo.SupplierLedgers", "SupId", c => c.Int());
            RenameColumn(table: "dbo.SupplierLedgers", name: "SupId", newName: "SuplierInfo_SupId");
            CreateIndex("dbo.SupplierLedgers", "SuplierInfo_SupId");
            AddForeignKey("dbo.SupplierLedgers", "SuplierInfo_SupId", "dbo.SuplierInfoes", "SupId");
        }
    }
}
