namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30052018m21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhSaleLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        InvoiceId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.TranId)
                .ForeignKey("dbo.PhInvoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhSaleLedgers", "InvoiceId", "dbo.PhInvoices");
            DropIndex("dbo.PhSaleLedgers", new[] { "InvoiceId" });
            DropTable("dbo.PhSaleLedgers");
        }
    }
}
