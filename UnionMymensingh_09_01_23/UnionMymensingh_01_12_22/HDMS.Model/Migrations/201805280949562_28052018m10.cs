namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoiceTypes", "InvoiceTypeShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhInvoiceTypes", "InvoiceTypeShortName");
        }
    }
}
