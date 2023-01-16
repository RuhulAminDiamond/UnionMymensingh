namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhInvoiceDetails", "InvoiceId", "dbo.PhInvoices");
            DropIndex("dbo.PhInvoiceDetails", new[] { "InvoiceId" });
            DropPrimaryKey("dbo.PhInvoices");
            AlterColumn("dbo.PhInvoiceDetails", "InvoiceId", c => c.Long(nullable: false));
            AlterColumn("dbo.PhInvoices", "InvoiceId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PhInvoices", "InvoiceId");
            CreateIndex("dbo.PhInvoiceDetails", "InvoiceId");
            AddForeignKey("dbo.PhInvoiceDetails", "InvoiceId", "dbo.PhInvoices", "InvoiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhInvoiceDetails", "InvoiceId", "dbo.PhInvoices");
            DropIndex("dbo.PhInvoiceDetails", new[] { "InvoiceId" });
            DropPrimaryKey("dbo.PhInvoices");
            AlterColumn("dbo.PhInvoices", "InvoiceId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PhInvoiceDetails", "InvoiceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PhInvoices", "InvoiceId");
            CreateIndex("dbo.PhInvoiceDetails", "InvoiceId");
            AddForeignKey("dbo.PhInvoiceDetails", "InvoiceId", "dbo.PhInvoices", "InvoiceId", cascadeDelete: true);
        }
    }
}
