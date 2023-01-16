namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CantInvoice_Model_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CantInvoices", "InvoiceNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CantInvoices", "InvoiceNumber", c => c.String());
        }
    }
}
