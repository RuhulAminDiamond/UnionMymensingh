namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhModel_Changes_Jun01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhIPDSaleLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        TranDate = c.DateTime(nullable: false),
                        TransactionTime = c.String(),
                        AdmissionId = c.Long(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.TranId);
            
            AddColumn("dbo.HpMedicineReturnIndentDetails", "InvoiceId", c => c.Long(nullable: false));
            AddColumn("dbo.PhInvoiceDetails", "RetQty", c => c.Double(nullable: false));
            AddColumn("dbo.PhInvoices", "OPDCustomerName", c => c.String());
            CreateIndex("dbo.HpMedicineReturnIndentDetails", "InvoiceId");
          //  AddForeignKey("dbo.HpMedicineReturnIndentDetails", "InvoiceId", "dbo.PhInvoices", "InvoiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpMedicineReturnIndentDetails", "InvoiceId", "dbo.PhInvoices");
            DropIndex("dbo.HpMedicineReturnIndentDetails", new[] { "InvoiceId" });
            DropColumn("dbo.PhInvoices", "OPDCustomerName");
            DropColumn("dbo.PhInvoiceDetails", "RetQty");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "InvoiceId");
            DropTable("dbo.PhIPDSaleLedgers");
        }
    }
}
