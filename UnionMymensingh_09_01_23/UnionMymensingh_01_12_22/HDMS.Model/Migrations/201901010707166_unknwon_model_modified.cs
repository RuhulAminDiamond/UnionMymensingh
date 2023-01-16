namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknwon_model_modified : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Suppliers");
            CreateTable(
                "dbo.CantSaleLedgers",
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
                .ForeignKey("dbo.CantInvoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            AlterColumn("dbo.Suppliers", "Supplierid", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Suppliers", "Supplierid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CantSaleLedgers", "InvoiceId", "dbo.CantInvoices");
            DropIndex("dbo.CantSaleLedgers", new[] { "InvoiceId" });
            DropPrimaryKey("dbo.Suppliers");
            AlterColumn("dbo.Suppliers", "Supplierid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.CantSaleLedgers");
            AddPrimaryKey("dbo.Suppliers", "Supplierid");
        }
    }
}
