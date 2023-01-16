namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29052018m29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoices", "BillNo", c => c.Long(nullable: false));
            AddColumn("dbo.PhInvoices", "AdmissionNo", c => c.Long(nullable: false));
            AddColumn("dbo.PhInvoices", "InvoiceType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhInvoices", "InvoiceType");
            DropColumn("dbo.PhInvoices", "AdmissionNo");
            DropColumn("dbo.PhInvoices", "BillNo");
        }
    }
}
