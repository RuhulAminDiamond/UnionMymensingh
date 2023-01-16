namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29052018m35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhInvoiceDetails", "BatchNo", c => c.String());
            AddColumn("dbo.PhInvoiceDetails", "ExpireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhInvoiceDetails", "ExpireDate");
            DropColumn("dbo.PhInvoiceDetails", "BatchNo");
        }
    }
}
